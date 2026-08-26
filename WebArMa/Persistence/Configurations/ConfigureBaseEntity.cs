using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WebArMa.Domain.Entities;

namespace WebArMa.Persistence.Configurations
{
    public class ConfigureBaseEntity
    {
        protected virtual void Config(ModelBuilder modelBuilder)
        {
            foreach (var entityType in modelBuilder.Model.GetEntityTypes().Where(x => typeof(WebArMaEntityBase).IsAssignableFrom(x.ClrType)))
            {
                var builder = modelBuilder.Entity(entityType.ClrType);
                builder.HasKey(nameof(WebArMaEntityBase.Id));
                builder.Property(nameof(WebArMaEntityBase.Guid)).IsRequired();
                builder.HasIndex(nameof(WebArMaEntityBase.Guid)).IsUnique();
                builder.Property(nameof(WebArMaEntityBase.CreatedAt)).IsRequired();
                builder.Property(nameof(WebArMaEntityBase.RowVersion)).IsRowVersion().IsConcurrencyToken();
                builder.HasQueryFilter(CreateIsDeletedFilter(entityType.ClrType));
            }
        }

        private static LambdaExpression CreateIsDeletedFilter(Type entityType)
        {
            var parameter = Expression.Parameter(entityType, "e");
            var deletedAt = Expression.Property(parameter, nameof(WebArMaEntityBase.DeletedAt));
            var body = Expression.Equal(deletedAt, Expression.Constant(null, typeof(DateTime?)));
            return Expression.Lambda(body, parameter);
        }
    }
}
