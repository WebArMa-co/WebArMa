using WebArMa.Domain.Entities;

namespace WebArMa.Identity.Domain.Entities
{
	public class Token : WebArMaEntityBase
	{
		public static Token Create(int userId, string tokenHash, DateTimeOffset expiresAt)
		{
			if (string.IsNullOrWhiteSpace(tokenHash))
			{
				throw new ArgumentException("توکن معتبر نمی‌باشد");
			}

			return new Token
			{
				UserId = userId,
				TokenHash = tokenHash,
				ExpiresAt = expiresAt
			};
		}

		public Token()
		{
			TokenHash = string.Empty;
		}

		public int UserId { get; private set; }
		public string TokenHash { get; private set; }
		public DateTimeOffset ExpiresAt { get; private set; }
		public DateTimeOffset? RevokedAt { get; private set; }

		public bool IsActive => RevokedAt == null && ExpiresAt > DateTimeOffset.UtcNow;

		public void Revoke()
		{
			RevokedAt = DateTimeOffset.UtcNow;
		}
	}
}