using Mediator;
using Microsoft.AspNetCore.Mvc;
using WebArMa.Application.Settings.CreateSetting;
using WebArMa.Application.Settings.Dtos;
using WebArMa.Presentation;

namespace WebArMa.EndPoint.Test.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SettingController(IMediator mediator) : SettingControllerBase(mediator)
    {
        [HttpGet]
        public override ValueTask<IEnumerable<SettingDto>> Get(string? key, string? section, string? type)
        {
            return base.Get(key, section, type);
        }

        [HttpPost]
        public override ValueTask<Guid> Post(CreateSettingCommand command)
        {
            return base.Post(command);
        }
    }
}
