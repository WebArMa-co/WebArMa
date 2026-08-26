using WebArMa.Application.Enums.Sort;

namespace WebArMa.Application.Dtos
{
    public record PaginationRequest
    {
        public int Page { get; init; } = 1;
        public int? PageSize { get; init; } = 10;
    }

    public record PaginationRequest<TSearch> : PaginationRequest where TSearch : class
    {
        public TSearch? Search { get; init; }
    }

    public record PaginationRequest<TSearch, TSort> : PaginationRequest<TSearch> where TSearch : class where TSort : Enum
    {
        public TSort? Sort { get; init; }
        public SortType SortType { get; init; } = SortType.Ascending;
    }
}
