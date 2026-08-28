using WebArMa.Blogs.Domain.Enums;
using WebArMa.Domain.Entities;

namespace WebArMa.Blogs.Domain.Entities
{
    public record BlogCategory : WebArMaEntityBase
    {
        public required string Name { get; set; }
        public required string Slug { get; set; }
        public string? Description { get; set; }
        public string? MetaTitle { get; set; }
        public string? MetaDescription { get; set; }
        public string? CanonicalUrl { get; set; }
        public string? OgImage { get; set; }
        public string? CoverImage { get; set; }
        public int? ParentId { get; set; }
        public int? SortOrder { get; set; }
        public virtual ICollection<Blog> Blogs { get; set; } = [];
        public virtual BlogCategory? Parent { get; set; }
    }

    public record Blog : WebArMaEntityBase
    {
        public required string Title { get; set; }
        public required string Slug { get; set; }
        public required string Content { get; set; }
        public string? MetaTitle { get; set; }
        public string? MetaDescription { get; set; }
        public string? CanonicalUrl { get; set; }
        public string? OgImage { get; set; }
        public string? CoverImage { get; set; }
        public DateTimeOffset PublishedAt { get; set; }
        public int AuthorId { get; set; }
        public Status Status { get; set; }
        public ICollection<BlogCategory> BlogCategories { get; set; } = [];
    }
}
