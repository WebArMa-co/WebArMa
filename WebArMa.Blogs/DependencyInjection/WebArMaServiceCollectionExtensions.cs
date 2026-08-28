using Microsoft.Extensions.DependencyInjection;
using WebArMa.Blogs.Persistence;
using WebArMa.Infrastructure;

namespace WebArMa.Blogs.DependencyInjection
{
	public static class WebArMaServiceCollectionExtensions
	{
		public static IServiceCollection AddWebArMaBlog(this IServiceCollection services)
		{
			services.AddScoped<IDbContextModelBuilder, WebArMaBlogModelConfiguration>();
			return services;
		}
	}
}
