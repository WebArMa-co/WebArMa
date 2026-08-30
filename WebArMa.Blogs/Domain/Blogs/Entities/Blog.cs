using WebArMa.Blogs.Domain.Blogs.Enums;
using WebArMa.Domain.Entities;

namespace WebArMa.Blogs.Domain.Blogs.Entities
{
    public sealed class Blog : WebArMaEntityBase
    {
        private readonly List<BlogCategory> _blogCategories = [];

        private Blog(string title, string slug, string content, Status status, int authorId, string metaDescription, DateTimeOffset publishedAt, string? metaTitle, string? canonicalUrl, string? ogImage, string? coverImage)
        {
            if (authorId <= 0)
            {
                throw new ArgumentException("شناسه نویسنده معتبر نیست.", nameof(authorId));
            }

            Title = NormalizeRequired(title, nameof(title));
            Slug = NormalizeSlug(slug);
            Content = NormalizeRequired(content, nameof(content));
            MetaDescription = NormalizeOptional(metaDescription);
            MetaTitle = NormalizeOptional(metaTitle);
            CanonicalUrl = NormalizeOptional(canonicalUrl);
            OgImage = NormalizeOptional(ogImage);
            CoverImage = NormalizeOptional(coverImage);
            Status = status;
            AuthorId = authorId;
            PublishedAt = publishedAt;
        }

        // EF Core
        private Blog()
        {
            Title = null!;
            Slug = null!;
            Content = null!;
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
        public IReadOnlyCollection<BlogCategory> BlogCategories => _blogCategories.AsReadOnly();

        public static Blog Create(string title, string slug, string content, Status status, int authorId, string metaDescription, DateTimeOffset publishedAt, string? metaTitle = null, string? canonicalUrl = null, string? ogImage = null, string? coverImage = null)
        {
            return new Blog(title, slug, content, status, authorId, metaDescription, publishedAt, metaTitle, canonicalUrl, ogImage, coverImage);
        }

        public void Update(string title, string slug, string content, Status status, int authorId, string metaDescription, DateTimeOffset publishedAt, string? metaTitle = null, string? canonicalUrl = null, string? ogImage = null, string? coverImage = null)
        {
            if (authorId <= 0)
            {
                throw new ArgumentException("شناسه نویسنده معتبر نیست.", nameof(authorId));
            }

            Title = NormalizeRequired(title, nameof(title));
            Slug = NormalizeSlug(slug);
            Content = NormalizeRequired(content, nameof(content));
            MetaDescription = NormalizeOptional(metaDescription);
            MetaTitle = NormalizeOptional(metaTitle);
            CanonicalUrl = NormalizeOptional(canonicalUrl);
            OgImage = NormalizeOptional(ogImage);
            CoverImage = NormalizeOptional(coverImage);
            Status = status;
            AuthorId = authorId;
            PublishedAt = publishedAt;
        }

        public void AddCategory(BlogCategory category)
        {
            ArgumentNullException.ThrowIfNull(category);

            if (!_blogCategories.Contains(category))
            {
                _blogCategories.Add(category);
            }
        }

        public void RemoveCategory(BlogCategory category)
        {
            ArgumentNullException.ThrowIfNull(category);

            _blogCategories.Remove(category);
        }

        public void ChangeStatus(Status status)
        {
            Status = status;
        }

        private static string NormalizeRequired(string value, string parameterName)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(value, parameterName);

            return value.Trim();
        }

        private static string? NormalizeOptional(string? value)
        {
            return string.IsNullOrWhiteSpace(value) ? null : value.Trim();
        }

        private static string NormalizeSlug(string value)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(value, nameof(value));

            return value.Trim().Replace(" ", "-");
        }
    }
}
