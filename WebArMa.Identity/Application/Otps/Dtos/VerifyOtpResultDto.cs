namespace WebArMa.Identity.Application.Otps.Dtos
{
	public sealed record VerifyOtpResult(Guid UserGuid, string Token, DateTimeOffset ExpiresAt);
}