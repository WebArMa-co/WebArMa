using Microsoft.EntityFrameworkCore;
using WebArMa.Infrastructure;

namespace WebArMa.Identity.Domain.Persistence
{
    public class WebArMaIdentityDbContext : IDbContextModelBuilder
    {
        public void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(WebArMaIdentityDbContext).Assembly);
        }
    }
}
