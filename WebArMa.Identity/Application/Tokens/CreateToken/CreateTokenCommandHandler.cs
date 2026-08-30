using System.Security.Cryptography;
using WebArMa.Application.Contexts;
using WebArMa.Application.Interfaces.Mediator;
using WebArMa.Identity.Application.Tokens.Dtos;
using WebArMa.Identity.Domain.Entities;

namespace WebArMa.Identity.Application.Tokens.CreateToken
{
	public class CreateTokenCommandHandler(IWebArMaDbContext dbContext) : IWebArMaCommandHandler<CreateTokenCommand, CreateTokenResultDto>
	{
		private const int ExpiryDays = 30;

		public async ValueTask<CreateTokenResultDto> Handle(CreateTokenCommand command, CancellationToken cancellationToken)
		{
			var rawToken = Convert.ToHexString(RandomNumberGenerator.GetBytes(32));
			var tokenHash = Convert.ToHexString(SHA256.HashData(System.Text.Encoding.UTF8.GetBytes(rawToken)));
			var expiresAt = DateTimeOffset.UtcNow.AddDays(ExpiryDays);

			var newToken = Token.Create(command.UserId, tokenHash, expiresAt);
			await dbContext.Set<Token>().AddAsync(newToken, cancellationToken);
			await dbContext.SaveChangesAsync(cancellationToken);

			return new CreateTokenResultDto(rawToken, expiresAt);
		}
	}
}