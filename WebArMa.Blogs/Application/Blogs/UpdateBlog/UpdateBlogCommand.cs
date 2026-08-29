using WebArMa.Application.Interfaces.Mediator;
using WebArMa.Blogs.Domain.Blogs.Enums;

namespace WebArMa.Blogs.Application.Blogs.CreateBlog
{
    public class UpdateBlogCommand(Guid guid, string title, string slug, string content, List<Guid> blogCategoryIds, Status status, string metaDescription, DateTimeOffset publishedAt, string? metaTitle = null, string? canonicalUrl = null, string? ogImage = null, string? coverImage = null) : IWebArMaCommand<Guid>
    {
        public Guid Guid { get; private set; } = guid;
        public string Title { get; private set; } = title;
        public string Slug { get; private set; } = slug;
        public string Content { get; private set; } = content;
        public string? MetaTitle { get; private set; } = metaTitle;
        public string MetaDescription { get; private set; } = metaDescription;
        public string? CanonicalUrl { get; private set; } = canonicalUrl;
        public string? OgImage { get; private set; } = ogImage;
        public string? CoverImage { get; private set; } = coverImage;
        public DateTimeOffset PublishedAt { get; private set; } = publishedAt;
        public Status Status { get; private set; } = status;
        public List<Guid> BlogCategoryIds { get; private set; } = blogCategoryIds;
    }
}
