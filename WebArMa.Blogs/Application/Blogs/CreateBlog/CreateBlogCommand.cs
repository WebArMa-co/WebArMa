using WebArMa.Application.Interfaces.Mediator;
using WebArMa.Blogs.Domain.Blogs.Enums;

namespace WebArMa.Blogs.Application.Blogs.CreateBlog
{
    public sealed record CreateBlogCommand(
        string Title,
        string Slug,
        string Content,
        IReadOnlyCollection<Guid> BlogCategoryIds,
        Status Status,
        string MetaDescription,
        DateTimeOffset PublishedAt,
        string? MetaTitle = null,
        string? CanonicalUrl = null,
        string? OgImage = null,
        string? CoverImage = null) : IWebArMaCommand<Guid>;
}
