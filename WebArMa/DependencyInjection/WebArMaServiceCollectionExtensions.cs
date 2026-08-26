using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebArMa.Application.Settings.CreateSetting;
using WebArMa.Persistence.Contexts;

namespace WebArMa.DependencyInjection
{
    public static class WebArMaServiceCollectionExtensions
    {
        public static IServiceCollection AddWebArMa(this IServiceCollection services, Action<DbContextOptionsBuilder> options)
        {
            services.AddDbContext<WebArMaDbContext>(options);
            services.AddValidatorsFromAssembly(typeof(CreateSettingCommandValidator).Assembly);
            services.AddMediator(options => options.ServiceLifetime = ServiceLifetime.Transient);
            return services;
        }
    }
}
