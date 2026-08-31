namespace WebArMa.Identity.Application.Interfaces.Services
{
	public interface IJwtTokenService
	{
		(string AccessToken, DateTimeOffset ExpiresAt) GenerateAccessToken(Guid userGuid, string phoneNumber);
	}
}