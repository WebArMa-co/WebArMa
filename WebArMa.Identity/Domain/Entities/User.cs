using WebArMa.Domain.Entities;
using WebArMa.Identity.Domain.Helpers;

namespace WebArMa.Identity.Domain.Entities
{
	public class User : WebArMaEntityBase
	{
		public static User Create(string phoneNumber, string? firstName = null, string? lastName = null, string? displayName = null)
		{
			if (!IranianPhoneNumber.IsValid(phoneNumber))
			{
				throw new ArgumentException("شماره تماس وارد شده معتبر نمی‌باشد");
			}

			return new User
			{
				FirstName = firstName?.Trim(),
				LastName = lastName?.Trim(),
				DisplayName = displayName?.Trim(),
				PhoneNumber = phoneNumber.Trim()
			};
		}

		public User()
		{
			PhoneNumber = string.Empty;
		}

		public string PhoneNumber { get; private set; }
		public string? FirstName { get; private set; }
		public string? LastName { get; private set; }
		public string? DisplayName { get; private set; }
		public string? PhotoUrl { get; private set; }
		public bool ProfileCompleted { get; private set; }
		public DateTimeOffset? PhoneVerifiedAt { get; private set; }

		public string EffectiveDisplayName => !string.IsNullOrWhiteSpace(DisplayName) ? DisplayName : PhoneNumber;

		public void CompleteProfile(string? firstName = null, string? lastName = null, string? displayName = null, string? photoUrl = null)
		{
			FirstName = firstName?.Trim();
			LastName = lastName?.Trim();
			DisplayName = displayName?.Trim();
			PhotoUrl = photoUrl?.Trim();
			ProfileCompleted = true;
		}

		public void MarkPhoneVerified()
		{
			PhoneVerifiedAt = DateTimeOffset.UtcNow;     /*for future when we need to change a phone number or ...*/
		}
	}
}