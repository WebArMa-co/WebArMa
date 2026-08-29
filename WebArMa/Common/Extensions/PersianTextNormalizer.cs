namespace WebArMa.Common.Extensions
{
    public static class PersianTextNormalizer
    {
        public static string Normalize(string value)
        {
            if (string.IsNullOrEmpty(value))
                return value;

            return value
                .Replace('ي', 'ی')
                .Replace('ى', 'ی')
                .Replace('ك', 'ک');
        }
    }
}
