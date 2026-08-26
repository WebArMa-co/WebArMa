using Microsoft.EntityFrameworkCore;
using WebArMa.Application.Contexts;
using WebArMa.Domain.Entities;
using WebArMa.Persistence.Configurations;

namespace WebArMa.Persistence.Contexts
{
    public class WebArMaDbContext(DbContextOptions options) : DbContext(options), IWebArMaDbContext
    {
        public DbSet<Setting> Settings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            ApplyBaseConfigurations(modelBuilder);

            OnModelCreatingPartial(modelBuilder);
        }

        protected virtual void OnModelCreatingPartial(ModelBuilder modelBuilder)
        {

        }

        private static void ApplyBaseConfigurations(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ConfigureBaseEntity).Assembly);
        }
    }
}
