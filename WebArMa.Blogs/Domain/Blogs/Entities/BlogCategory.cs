using WebArMa.Domain.Entities;

namespace WebArMa.Blogs.Domain.Blogs.Entities
{
    public sealed class BlogCategory : WebArMaEntityBase
    {
        private readonly List<Blog> _blogs = [];

        private BlogCategory(string name, string slug, string? description, string? metaTitle, string? metaDescription, string? canonicalUrl, string? ogImage, string? coverImage, int? parentId, int? sortOrder)
        {
            Name = NormalizeRequired(name, nameof(name));
            Slug = NormalizeSlug(slug);
            Description = NormalizeOptional(description);
            MetaTitle = NormalizeOptional(metaTitle);
            MetaDescription = NormalizeOptional(metaDescription);
            CanonicalUrl = NormalizeOptional(canonicalUrl);
            OgImage = NormalizeOptional(ogImage);
            CoverImage = NormalizeOptional(coverImage);

            if (parentId is <= 0)
            {
                throw new ArgumentException("شناسه دسته والد معتبر نیست.", nameof(parentId));
            }

            if (sortOrder is < 0)
            {
                throw new ArgumentException("ترتیب دسته نمی‌تواند منفی باشد.", nameof(sortOrder));
            }

            ParentId = parentId;
            SortOrder = sortOrder;
        }

        private BlogCategory()
        {
            Name = null!;
            Slug = null!;
        }

        public string Name { get; private set; }
        public string Slug { get; private set; }
        public string? Description { get; private set; }
        public string? MetaTitle { get; private set; }
        public string? MetaDescription { get; private set; }
        public string? CanonicalUrl { get; private set; }
        public string? OgImage { get; private set; }
        public string? CoverImage { get; private set; }
        public int? ParentId { get; private set; }
        public int? SortOrder { get; private set; }
        public IReadOnlyCollection<Blog> Blogs => _blogs.AsReadOnly();
        public BlogCategory? Parent { get; private set; }

        public static BlogCategory Create(string name, string slug, string? description = null, string? metaTitle = null, string? metaDescription = null, string? canonicalUrl = null, string? ogImage = null, string? coverImage = null, int? parentId = null, int? sortOrder = null)
        {
            return new BlogCategory(name, slug, description, metaTitle, metaDescription, canonicalUrl, ogImage, coverImage, parentId, sortOrder);
        }

        public void Update(string name, string slug, string? description = null, string? metaTitle = null, string? metaDescription = null, string? canonicalUrl = null, string? ogImage = null, string? coverImage = null, int? parentId = null, int? sortOrder = null)
        {
            if (parentId is <= 0)
            {
                throw new ArgumentException("شناسه دسته والد معتبر نیست.", nameof(parentId));
            }

            if (sortOrder is < 0)
            {
                throw new ArgumentException("ترتیب دسته نمی‌تواند منفی باشد.", nameof(sortOrder));
            }

            Name = NormalizeRequired(name, nameof(name));
            Slug = NormalizeSlug(slug);
            Description = NormalizeOptional(description);
            MetaTitle = NormalizeOptional(metaTitle);
            MetaDescription = NormalizeOptional(metaDescription);
            CanonicalUrl = NormalizeOptional(canonicalUrl);
            OgImage = NormalizeOptional(ogImage);
            CoverImage = NormalizeOptional(coverImage);
            ParentId = parentId;
            SortOrder = sortOrder;
        }

        public void ChangeParent(int? parentId)
        {
            if (parentId is <= 0)
            {
                throw new ArgumentException("شناسه دسته والد معتبر نیست.", nameof(parentId));
            }

            if (parentId == Id)
            {
                throw new InvalidOperationException("دسته نمی‌تواند والد خودش باشد.");
            }

            ParentId = parentId;
        }

        public void ChangeSortOrder(int? sortOrder)
        {
            if (sortOrder is < 0)
            {
                throw new ArgumentException("ترتیب دسته نمی‌تواند منفی باشد.", nameof(sortOrder));
            }

            SortOrder = sortOrder;
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
