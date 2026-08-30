using WebArMa.Application.Dtos;

namespace WebArMa.Application.Settings.Dtos
{
    public record SettingDto : WebArMaDtoBase
    {
        public string Key { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public string Section { get; set; } = string.Empty;
        public string? Value { get; set; }
    }
}
