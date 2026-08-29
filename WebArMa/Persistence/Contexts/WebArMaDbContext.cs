using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebArMa.Application.Contexts;
using WebArMa.Common.Extensions;
using WebArMa.Domain.Entities;
using WebArMa.Infrastructure;
using WebArMa.Persistence.Configurations;

namespace WebArMa.Persistence.Contexts
{
    public class WebArMaDbContext(DbContextOptions<WebArMaDbContext> options, IEnumerable<IDbContextModelBuilder> modelBuilders) : DbContext(options), IWebArMaDbContext
    {
        public DbSet<Setting> Settings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            ApplyBaseConfigurations(modelBuilder);

            OnModelCreatingPartial(modelBuilder);

            foreach (var modelBuilderModule in modelBuilders)
            {
                modelBuilderModule.Configure(modelBuilder);
            }

            var converter = new ValueConverter<string, string>(v => PersianTextNormalizer.Normalize(v),v => v);

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                foreach (var property in entityType.GetProperties())
                {
                    if (property.ClrType == typeof(string))
                    {
                        property.SetValueConverter(converter);
                    }
                }
            }
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
