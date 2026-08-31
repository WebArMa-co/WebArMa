using Mediator;
using Microsoft.EntityFrameworkCore;
using WebArMa.Application.Contexts;
using WebArMa.Application.Interfaces.Mediator;
using WebArMa.Identity.Application.Interfaces.Services;
using WebArMa.Identity.Application.Otps.Dtos;
using WebArMa.Identity.Application.Tokens.CreateToken;
using WebArMa.Identity.Application.Users.CreateUser;
using WebArMa.Identity.Domain.Entities;

namespace WebArMa.Identity.Application.Otps.VerifyOtp
{
	public class VerifyOtpCommandHandler(IWebArMaDbContext dbContext, IMediator mediator, IJwtTokenService jwtTokenService) : IWebArMaCommandHandler<VerifyOtpCommand, VerifyOtpResult>
	{
		public async ValueTask<VerifyOtpResult> Handle(VerifyOtpCommand command, CancellationToken cancellationToken)
		{
			var otp = await dbContext.Set<OtpCode>()
				.Where(o => o.PhoneNumber == command.PhoneNumber && o.UsedAt == null)
				.OrderByDescending(o => o.CreatedAt)
				.FirstOrDefaultAsync(cancellationToken);

			if (otp == null || otp.IsExpired)
			{
				throw new ArgumentException("کد تایید منقضی شده یا نامعتبر است");
			}

			if (otp.HasExceededAttempts)
			{
				throw new ArgumentException("تعداد تلاش‌های مجاز به پایان رسیده است");
			}

			if (otp.CodeHash != OtpHasher.Hash(command.Code))
			{
				otp.IncreaseAttempt();
				await dbContext.SaveChangesAsync(cancellationToken);
				throw new ArgumentException("کد تایید نادرست است");
			}

			otp.MarkAsUsed();
			await dbContext.SaveChangesAsync(cancellationToken);

			var userGuid = await mediator.Send(new CreateUserCommand(command.PhoneNumber), cancellationToken);
			var user = await dbContext.Set<User>().FirstAsync(u => u.Guid == userGuid, cancellationToken);

			var (accessToken, accessTokenExpiresAt) = jwtTokenService.GenerateAccessToken(user.Guid, user.PhoneNumber);
			var refreshToken = await mediator.Send(new CreateTokenCommand(user.Id), cancellationToken);

			return new VerifyOtpResult(user.Guid, accessToken, accessTokenExpiresAt, refreshToken.RawToken, refreshToken.ExpiresAt);
		}
	}
}