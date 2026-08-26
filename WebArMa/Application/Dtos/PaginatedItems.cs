namespace WebArMa.Application.Dtos
{
    public sealed record PaginatedItems<T>(IReadOnlyList<T> Data, int TotalItems, int PageIndex, int? PageSize) where T : class
    {
        public IReadOnlyList<T> Data { get; set; } = Data;
        public Pager Pager { get; } = new(TotalItems, PageIndex, PageSize);
    }

    public sealed record Pager
    {
        public Pager(long totalItems, int currentPage = 1, int? pageSize = 10, int maxPages = 5)
        {
            ArgumentOutOfRangeException.ThrowIfNegative(totalItems);
            ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(maxPages, 0);

            if (pageSize is <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(pageSize));
            }

            TotalItems = totalItems;
            PageSize = pageSize ?? 0;
            MaxPages = maxPages;

            TotalPages = pageSize.HasValue && totalItems > 0 ? (int)Math.Ceiling((decimal)totalItems / pageSize.Value) : 0;

            CurrentPage = TotalPages == 0 ? 1 : Math.Clamp(currentPage, 1, TotalPages);

            Pages = CalculatePages;
        }

        public long TotalItems { get; }
        public int PageSize { get; }
        public int MaxPages { get; }
        public int CurrentPage { get; }
        public int TotalPages { get; }
        public IReadOnlyList<int> Pages { get; }
        public bool HasPreviousPage => CurrentPage > 1;
        public bool HasNextPage => CurrentPage < TotalPages;

        private IReadOnlyList<int> CalculatePages
        {
            get
            {
                if (TotalPages == 0)
                {
                    return [];
                }

                if (TotalPages <= MaxPages)
                {
                    return [.. Enumerable.Range(1, TotalPages)];
                }

                var pagesBeforeCurrent = MaxPages / 2;
                var pagesAfterCurrent = MaxPages - pagesBeforeCurrent - 1;

                int startPage;
                int endPage;

                if (CurrentPage <= pagesBeforeCurrent + 1)
                {
                    startPage = 1;
                    endPage = MaxPages;
                }
                else if (CurrentPage + pagesAfterCurrent >= TotalPages)
                {
                    startPage = TotalPages - MaxPages + 1;
                    endPage = TotalPages;
                }
                else
                {
                    startPage = CurrentPage - pagesBeforeCurrent;
                    endPage = CurrentPage + pagesAfterCurrent;
                }

                return [.. Enumerable.Range(startPage, endPage - startPage + 1)];
            }
        }
    }
}
