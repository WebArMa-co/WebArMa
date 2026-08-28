using Mapster;
using Microsoft.EntityFrameworkCore;
using WebArMa.Application.Contexts;
using WebArMa.Application.Dtos;
using WebArMa.Application.Interfaces.Mediator;
using WebArMa.Application.Mappings;

namespace WebArMa.Application.Settings.GetSettings
{
    public class GetSettingsQueryHandler(IWebArMaDbContext dbContext, WebArMaTypeAdapterConfig config) : IWebArMaQueryHandler<GetSettingsQuery, IEnumerable<SettingDto>>
    {
        public async ValueTask<IEnumerable<SettingDto>> Handle(GetSettingsQuery query, CancellationToken cancellationToken)
        {
            var dbQuery = dbContext.Settings.AsQueryable();

            if (query.Key != null)
            {
                dbQuery = dbQuery.Where(s => s.Key == query.Key);
            }

            if (query.Section != null)
            {
                dbQuery = dbQuery.Where(s => s.Section == query.Section);
            }

            if (query.Type != null)
            {
                dbQuery = dbQuery.Where(s => s.Type == query.Type);
            }

            return await dbQuery.ProjectToType<SettingDto>(config).ToListAsync(cancellationToken: cancellationToken);
        }
    }
}
