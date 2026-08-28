using Microsoft.EntityFrameworkCore;
using WebArMa.Domain.Entities;

namespace WebArMa.Application.Contexts
{
    public interface IWebArMaDbContext
    {
        DbSet<Setting> Settings { get; set; }
        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
