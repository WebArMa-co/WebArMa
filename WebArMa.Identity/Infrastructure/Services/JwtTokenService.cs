using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using WebArMa.Identity.Application.Interfaces.Services;
using WebArMa.Identity.Application.Settings;

namespace WebArMa.Identity.Infrastructure.Services
{
	public class JwtTokenService(IOptions<JwtSettings> options) : IJwtTokenService
	{
		private readonly JwtSettings _settings = options.Value;

		public (string AccessToken, DateTimeOffset ExpiresAt) GenerateAccessToken(Guid userGuid, string phoneNumber)
		{
			var expiresAt = DateTimeOffset.UtcNow.AddMinutes(_settings.AccessTokenExpiryMinutes);

			var claims = new[]
			{
				new Claim(ClaimTypes.NameIdentifier, userGuid.ToString()),
				new Claim("phone_number", phoneNumber)
			};

			var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_settings.SecretKey));
			var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

			var token = new JwtSecurityToken(
				issuer: _settings.Issuer,
				audience: _settings.Audience,
				claims: claims,
				expires: expiresAt.UtcDateTime,
				signingCredentials: credentials);

			return (new JwtSecurityTokenHandler().WriteToken(token), expiresAt);
		}
	}
}