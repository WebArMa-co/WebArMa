using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebArMa.Application.Contexts;
using WebArMa.Application.Settings.CreateSetting;
using WebArMa.Common.Extensions;
using WebArMa.Persistence.Contexts;

namespace WebArMa.DependencyInjection
{
    public static class WebArMaServiceCollectionExtensions
    {
        public static IServiceCollection AddWebArMa(this IServiceCollection services, Action<DbContextOptionsBuilder> options)
        {
            services.AddWebArMaMapping();
            services.AddDbContext<WebArMaDbContext>(options);
            services.AddScoped<IWebArMaDbContext>(provider => provider.GetRequiredService<WebArMaDbContext>());
            services.AddValidatorsFromAssembly(typeof(CreateSettingCommandValidator).Assembly);
            services.AddMediator(options => options.ServiceLifetime = ServiceLifetime.Transient);
            return services;
        }
    }
}
