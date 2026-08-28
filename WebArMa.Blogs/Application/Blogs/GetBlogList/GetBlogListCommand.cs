using WebArMa.Application.Dtos;
using WebArMa.Application.Enums.Sort;
using WebArMa.Application.Interfaces.Mediator;
using WebArMa.Blogs.Application.Blogs.Dtos;
using WebArMa.Blogs.Application.Blogs.Enums;
using WebArMa.Blogs.Domain.Blogs.Enums;

namespace WebArMa.Blogs.Application.Blogs.GetBlogList
{
    public class GetBlogListCommand(int pageNumber = 1, int pageSize = 10, string? search = null, Status? status = null) : IWebArMaCommand<PaginatedItems<BlogDto>>
    {
        public int PageNumber { get; private set; } = pageNumber;
        public int PageSize { get; private set; } = pageSize;
        public string? Search { get; private set; } = search;
        public Status? Status { get; private set; } = status;
        public SortType SortType { get; set; } = SortType.Descending;
        public BlogSort SortBy { get; set; } = BlogSort.UpdateTime;
    }
}
