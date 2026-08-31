namespace WebArMa.Identity.Application.Otps.Dtos
{
	public sealed record VerifyOtpResult(
		Guid UserGuid,
		string AccessToken,
		DateTimeOffset AccessTokenExpiresAt,
		string RefreshToken,
		DateTimeOffset RefreshTokenExpiresAt);
}