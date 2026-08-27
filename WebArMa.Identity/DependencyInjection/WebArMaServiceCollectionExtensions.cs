using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebArMa.Identity.Domain.Persistence;
using WebArMa.Infrastructure;

namespace WebArMa.Identity.DependencyInjection
{
    public static class WebArMaServiceCollectionExtensions
    {
        public static IServiceCollection AddWebArMaIdentity(this IServiceCollection services)
        {
            services.AddScoped<IDbContextModelBuilder, WebArMaIdentityDbContext>();
            return services;
        }
    }
}
