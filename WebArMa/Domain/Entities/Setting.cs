namespace WebArMa.Domain.Entities
{
    public record Setting : WebArMaEntityBase
    {
        public static Setting Create(string key, string type, string section, string? value = null)
        {
            return new Setting
            {
                Key = key,
                Type = type,
                Section = section,
                Value = value
            };
        }

        public required string Key { get; set; }
        public required string Type { get; set; }
        public required string Section { get; set; }
        public string? Value { get; set; }
    }
}
