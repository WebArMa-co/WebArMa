using WebArMa.Domain.Entities;
using WebArMa.Identity.Domain.Helpers;

namespace WebArMa.Identity.Domain.Entities
{
	public class OtpCode : WebArMaEntityBase
	{
		private const int MaxAttempts = 5;

		public static OtpCode Create(string phoneNumber, string codeHash, DateTimeOffset expiresAt)
		{
			if (!IranianPhoneNumber.IsValid(phoneNumber))
			{
				throw new ArgumentException("شماره تماس وارد شده معتبر نمی‌باشد");
			}

			if (string.IsNullOrWhiteSpace(codeHash))
			{
				throw new ArgumentException("کد تایید معتبر نمی‌باشد");
			}

			return new OtpCode
			{
				PhoneNumber = phoneNumber.Trim(),
				CodeHash = codeHash,
				ExpiresAt = expiresAt
			};
		}

		public OtpCode()
		{
			PhoneNumber = string.Empty;
			CodeHash = string.Empty;
		}

		public string PhoneNumber { get; private set; }
		public string CodeHash { get; private set; }
		public DateTimeOffset ExpiresAt { get; private set; }
		public int AttemptCount { get; private set; }
		public DateTimeOffset? UsedAt { get; private set; }

		public bool IsExpired => ExpiresAt <= DateTimeOffset.UtcNow;
		public bool IsUsed => UsedAt.HasValue;
		public bool HasExceededAttempts => AttemptCount >= MaxAttempts;
		public bool IsActive => !IsUsed && !IsExpired && !HasExceededAttempts;

		public void IncreaseAttempt()
		{
			AttemptCount++;
		}

		public void MarkAsUsed()
		{
			UsedAt = DateTimeOffset.UtcNow;
		}
	}
}