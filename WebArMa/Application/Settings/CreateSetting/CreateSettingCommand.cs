using WebArMa.Application.Interfaces.Mediator;

namespace WebArMa.Application.Settings.CreateSetting
{
    public sealed class CreateSettingCommand : IWebArMaCommand<Guid>
    {
        public string Key { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public string Section { get; set; } = string.Empty;
        public string? Value { get; set; }
    }
}
