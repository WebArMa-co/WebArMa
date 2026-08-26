using Microsoft.EntityFrameworkCore;
using WebArMa.Domain.Entities;

namespace WebArMa.Application.Contexts
{
    public interface IWebArMaDbContext
    {
        DbSet<Setting> Settings { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
