using WebArMa.Application.Dtos;
using WebArMa.Application.Interfaces.Mediator;
using WebArMa.Blogs.Application.Blogs.Dtos;
using WebArMa.Blogs.Domain.Blogs.Enums;

namespace WebArMa.Blogs.Application.Blogs.GetBlogList
{
    public sealed record GetBlogListCommand(
        int PageNumber = 1,
        int PageSize = 10,
        string? Search = null,
        Status? Status = null) : IWebArMaCommand<PagedResult<BlogDto>>;
}
