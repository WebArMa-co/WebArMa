using WebArMa.Application.Dtos;
using WebArMa.Domain.Entities;

namespace WebArMa.Application.Mappings
{
    public class SettingMapping : IWebArMaMapperConfiguration
    {
        public void Register(WebArMaTypeAdapterConfig config)
        {
            config.NewConfig<Setting, SettingDto>();
        }
    }
}
