namespace WebArMa.Identity.Application.Tokens.Dtos
{
	public sealed record CreateTokenResultDto(string RawToken, DateTimeOffset ExpiresAt);
}