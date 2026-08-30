using Microsoft.EntityFrameworkCore;
using WebArMa.Infrastructure;

namespace WebArMa.Identity.Persistence
{
	public class WebArMaIdentityModelConfiguration : IDbContextModelBuilder
	{
		public void Configure(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfigurationsFromAssembly(typeof(WebArMaIdentityModelConfiguration).Assembly);
		}
	}
}
