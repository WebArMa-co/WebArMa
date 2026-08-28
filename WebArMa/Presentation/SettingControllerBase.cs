using Mediator;
using WebArMa.Application.Settings.CreateSetting;
using WebArMa.Application.Settings.Dtos;
using WebArMa.Application.Settings.GetSettings;

namespace WebArMa.Presentation
{
    public class SettingControllerBase(IMediator mediator)
    {
        public virtual ValueTask<Guid> Post(CreateSettingCommand command)
        {
            return mediator.Send(command);
        }

        public virtual ValueTask<IEnumerable<SettingDto>> Get(string? key, string? section, string? type)
        {
            var query = new GetSettingsQuery(key, section, type);
            return mediator.Send(query);
        }
    }
}
