using WebArMa.Application.Dtos;

namespace WebArMa.Identity.Application.Tokens.Dtos
{
	public record TokenDto : WebArMaDtoBase
	{
		public int UserId { get; set; }
		public DateTimeOffset ExpiresAt { get; set; }
		public DateTimeOffset? RevokedAt { get; set; }
		public bool IsActive { get; set; }
	}
}