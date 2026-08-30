using Microsoft.EntityFrameworkCore;
using WebArMa.Application.Dtos;

namespace WebArMa.Common.Extensions
{
    public static class Pagination
    {
        public static IQueryable<T> Paginate<T>(this IQueryable<T> source, int page, int pageSize)
        {
            ArgumentNullException.ThrowIfNull(source);
            ArgumentOutOfRangeException.ThrowIfLessThan(page, 1);
            ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(pageSize, 0);

            return source.Skip((page - 1) * pageSize).Take(pageSize);
        }

        public static IEnumerable<T> Paginate<T>(this IEnumerable<T> source, int page, int pageSize)
        {
            ArgumentNullException.ThrowIfNull(source);
            ArgumentOutOfRangeException.ThrowIfLessThan(page, 1);
            ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(pageSize, 0);

            return source.Skip((page - 1) * pageSize).Take(pageSize);
        }

        public static async Task<PagedResult<T>> ToPaginatedAsync<T>(this IQueryable<T> source, int page, int pageSize, CancellationToken cancellationToken = default) where T : class
        {
            ArgumentNullException.ThrowIfNull(source);
            ArgumentOutOfRangeException.ThrowIfLessThan(page, 1);
            ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(pageSize, 0);

            var totalItems = await source.CountAsync(cancellationToken);

            var data = await source.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync(cancellationToken);

            return new PagedResult<T>(data, totalItems, page, pageSize);
        }
    }
}
