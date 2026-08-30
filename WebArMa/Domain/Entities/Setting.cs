namespace WebArMa.Domain.Entities
{
    public sealed class Setting : WebArMaEntityBase
    {
        private Setting(string key, string type, string section, string? value)
        {
            Key = NormalizeRequired(key, nameof(key));
            Type = NormalizeRequired(type, nameof(type));
            Section = NormalizeRequired(section, nameof(section));
            Value = NormalizeOptional(value);
        }

        private Setting()
        {
            Key = null!;
            Type = null!;
            Section = null!;
        }

        public string Key { get; private set; }
        public string Type { get; private set; }
        public string Section { get; private set; }
        public string? Value { get; private set; }

        public static Setting Create(string key, string type, string section, string? value = null)
        {
            return new Setting(key, type, section, value);
        }

        public void UpdateValue(string? value)
        {
            Value = NormalizeOptional(value);
        }

        public void Update(string key, string type, string section, string? value = null)
        {
            Key = NormalizeRequired(key, nameof(key));
            Type = NormalizeRequired(type, nameof(type));
            Section = NormalizeRequired(section, nameof(section));
            Value = NormalizeOptional(value);
        }

        private static string NormalizeRequired(string value, string parameterName)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(value, parameterName);

            return value.Trim();
        }

        private static string? NormalizeOptional(string? value)
        {
            return string.IsNullOrWhiteSpace(value) ? null : value.Trim();
        }
    }
}
