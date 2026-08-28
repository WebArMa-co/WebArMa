using WebArMa.Application.Dtos;
using WebArMa.Application.Interfaces.Mediator;

namespace WebArMa.Application.Settings.GetSettings
{
    public class GetSettingsQuery(string? key, string? section, string? type) : IWebArMaQuery<IEnumerable<SettingDto>>
    {
        public string? Key { get; private set; } = key;
        public string? Section { get; private set; } = section;
        public string? Type { get; private set; } = type;
    }
}
