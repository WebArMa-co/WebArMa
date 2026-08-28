using Microsoft.Extensions.DependencyInjection;
using WebArMa.Identity.Persistence;
using WebArMa.Infrastructure;

namespace WebArMa.Identity.DependencyInjection
{
	public static class WebArMaServiceCollectionExtensions
	{
		public static IServiceCollection AddWebArMaIdentity(this IServiceCollection services)
		{
			services.AddScoped<IDbContextModelBuilder, WebArMaIdentityModelConfiguration>();
			return services;
		}
	}
}
