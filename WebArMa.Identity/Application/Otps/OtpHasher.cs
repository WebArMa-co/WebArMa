using System.Security.Cryptography;
using System.Text;

namespace WebArMa.Identity.Application.Otps
{
	public static class OtpHasher
	{
		public static string Hash(string value)
		{
			return Convert.ToHexString(SHA256.HashData(Encoding.UTF8.GetBytes(value)));
		}
	}
}