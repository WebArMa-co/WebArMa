using WebArMa.Application.Dtos;
using WebArMa.Blogs.Domain.Blogs.Enums;

namespace WebArMa.Blogs.Application.Blogs.Dtos
{
    public class BlogDto : WebArMaDtoBase
    {
        public string Title { get; private set; } = string.Empty;
        public string Slug { get; private set; } = string.Empty;
        public string Content { get; private set; } = string.Empty;
        public string? MetaTitle { get; private set; }
        public string? MetaDescription { get; private set; }
        public string? CanonicalUrl { get; private set; }
        public string? OgImage { get; private set; }
        public string? CoverImage { get; private set; }
        public DateTimeOffset PublishedAt { get; private set; }
        public int AuthorId { get; private set; }
        public Status Status { get; private set; }
    }
}
