using WebArMa.Blogs.Domain.Blogs.Enums;
using WebArMa.Domain.Entities;

namespace WebArMa.Blogs.Domain.Blogs.Entities
{
    public class Blog : WebArMaEntityBase
    {
        //TO DO

        public static Blog Create(string title, string slug, string content, List<BlogCategory> blogCategories, Status status, int authorId, string metaDescription, DateTimeOffset publishedAt, string? metaTitle = null, string? canonicalUrl = null, string? ogImage = null, string? coverImage = null)
        {
            return new Blog
            {
                Title = title.Trim(),
                Slug = slug.Trim().Replace(" ", "-"),
                Content = content.Trim(),
                BlogCategories = blogCategories,
                Status = status,
                AuthorId = authorId,
                MetaDescription = metaDescription.Trim(),
                MetaTitle = metaTitle?.Trim(),
                CanonicalUrl = canonicalUrl?.Trim(),
                OgImage = ogImage?.Trim(),
                CoverImage = coverImage?.Trim(),
                PublishedAt = publishedAt
            };
        }

        public static void Update(Blog blog, string title, string slug, string content, List<BlogCategory> blogCategories, Status status, int authorId, string metaDescription, DateTimeOffset publishedAt, string? metaTitle = null, string? canonicalUrl = null, string? ogImage = null, string? coverImage = null)
        {
            blog.Title = title.Trim();
            blog.Slug = slug.Trim().Replace(" ", "-");
            blog.Content = content.Trim();
            blog.BlogCategories = blogCategories;
            blog.Status = status;
            blog.AuthorId = authorId;
            blog.MetaDescription = metaDescription.Trim();
            blog.MetaTitle = metaTitle?.Trim();
            blog.CanonicalUrl = canonicalUrl?.Trim();
            blog.OgImage = ogImage?.Trim();
            blog.CoverImage = coverImage?.Trim();
            blog.PublishedAt = publishedAt;
        }

        private Blog()
        {
            Title = string.Empty;
            Slug = string.Empty;
            Content = string.Empty;
            PublishedAt = DateTimeOffset.UtcNow;
        }

        public string Title { get; private set; }
        public string Slug { get; private set; }
        public string Content { get; private set; }
        public string? MetaTitle { get; private set; }
        public string? MetaDescription { get; private set; }
        public string? CanonicalUrl { get; private set; }
        public string? OgImage { get; private set; }
        public string? CoverImage { get; private set; }
        public DateTimeOffset PublishedAt { get; private set; }
        public int AuthorId { get; private set; }
        public Status Status { get; private set; }
        public ICollection<BlogCategory> BlogCategories { get; private set; } = [];
    }
}
