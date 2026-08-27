using System.Text.RegularExpressions;

namespace WebArMa.Identity.Domain.Helpers
{
    public static class IranianPhoneNumber
    {
        private static readonly Regex Pattern = new(@"^09\d{9}$", RegexOptions.Compiled);

        public static bool IsValid(string? phoneNumber)
        {
            return !string.IsNullOrWhiteSpace(phoneNumber) && Pattern.IsMatch(phoneNumber);
        }
    }
}
