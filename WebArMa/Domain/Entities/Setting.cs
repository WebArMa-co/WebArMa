namespace WebArMa.Domain.Entities
{
    public record Setting : WebArMaEntityBase
    {
        public static Setting Create(string key, string type, string section, string? value = null)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                throw new ArgumentException("شناسه تنظیمات الزامی است");
            }

            if (string.IsNullOrWhiteSpace(type))
            {
                throw new ArgumentException("نوع تنظیمات الزامی است");
            }

            if (string.IsNullOrWhiteSpace(section))
            {
                throw new ArgumentException("بخش تنظیمات الزامی است");
            }

            return new Setting
            {
                Key = key,
                Type = type,
                Section = section,
                Value = value
            };
        }

        public Setting()
        {
            Key = string.Empty;
            Type = string.Empty;
            Section = string.Empty;
        }

        public string Key { get; private set; }
        public string Type { get; private set; }
        public string Section { get; private set; }
        public string? Value { get; private set; }
    }
}
