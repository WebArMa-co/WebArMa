using WebArMa.Application.Dtos;

namespace WebArMa.Identity.Application.Users.Dtos
{
	public class UserDto : WebArMaDtoBase
	{
		public string PhoneNumber { get; set; } = string.Empty;
		public string? FirstName { get; set; }
		public string? LastName { get; set; }
		public string? DisplayName { get; set; }
		public string? PhotoUrl { get; set; }
		public bool ProfileCompleted { get; set; }
		public DateTimeOffset? PhoneVerifiedAt { get; set; }
	}
}