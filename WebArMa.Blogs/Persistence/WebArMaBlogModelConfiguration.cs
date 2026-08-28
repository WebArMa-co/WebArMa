using Microsoft.EntityFrameworkCore;
using WebArMa.Infrastructure;

namespace WebArMa.Blogs.Persistence
{
    public class WebArMaBlogModelConfiguration : IDbContextModelBuilder
    {
        public void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(WebArMaBlogModelConfiguration).Assembly);
        }
    }
}
