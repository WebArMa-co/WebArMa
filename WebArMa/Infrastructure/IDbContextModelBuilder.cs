using Microsoft.EntityFrameworkCore;

namespace WebArMa.Infrastructure
{
    public interface IDbContextModelBuilder
    {
        void Configure(ModelBuilder modelBuilder);
    }
}
