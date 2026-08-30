using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using WebArMa.Application.Contexts;
using WebArMa.Application.Interfaces.Mediator;
using WebArMa.Identity.Application.Interfaces.Services;
using WebArMa.Identity.Domain.Entities;

namespace WebArMa.Identity.Application.Otps.RequestOtp
{
	public class RequestOtpCommandHandler(IWebArMaDbContext dbContext, ISmsService smsService) : IWebArMaCommandHandler<RequestOtpCommand, bool>
	{
		private const int CodeLength = 5;
		private const int ExpiryMinutes = 2;
		private const int ResendCooldownSeconds = 60;

		public async ValueTask<bool> Handle(RequestOtpCommand command, CancellationToken cancellationToken)
		{
			var lastOtp = await dbContext.Set<OtpCode>()
				.Where(o => o.PhoneNumber == command.PhoneNumber)
				.OrderByDescending(o => o.CreatedAt)
				.FirstOrDefaultAsync(cancellationToken);

			if (lastOtp != null && lastOtp.CreatedAt.AddSeconds(ResendCooldownSeconds) > DateTimeOffset.UtcNow)
			{
				throw new ArgumentException("لطفا کمی صبر کنید و دوباره تلاش کنید");
			}

			var code = GenerateCode(CodeLength);
			var codeHash = OtpHasher.Hash(code);
			var expiresAt = DateTimeOffset.UtcNow.AddMinutes(ExpiryMinutes);

			var newOtp = OtpCode.Create(command.PhoneNumber, codeHash, expiresAt);
			await dbContext.Set<OtpCode>().AddAsync(newOtp, cancellationToken);
			await dbContext.SaveChangesAsync(cancellationToken);

			await smsService.SendAsync(command.PhoneNumber, $"کد ورود شما: {code}", cancellationToken);

			return true;
		}

		private static string GenerateCode(int length)
		{
			var max = (int)Math.Pow(10, length);
			var code = RandomNumberGenerator.GetInt32(0, max);
			return code.ToString(new string('0', length));
		}
	}
}