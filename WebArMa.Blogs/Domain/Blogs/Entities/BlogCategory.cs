using WebArMa.Domain.Entities;

namespace WebArMa.Blogs.Domain.Blogs.Entities
{
    public class BlogCategory : WebArMaEntityBase
    {
        public static BlogCategory Create(string name, string slug, string? description = null, string? metaTitle = null, string? metaDescription = null, string? canonicalUrl = null, string? ogImage = null, string? coverImage = null, int? parentId = null, int? sortOrder = null)
        {
            return new BlogCategory
            {
                Name = name,
                Slug = slug,
                Description = description,
                MetaTitle = metaTitle,
                MetaDescription = metaDescription,
                CanonicalUrl = canonicalUrl,
                OgImage = ogImage,
                CoverImage = coverImage,
                ParentId = parentId,
                SortOrder = sortOrder,
            };
        }

        public BlogCategory()
        {
            Name = string.Empty;
            Slug = string.Empty;
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
        public virtual ICollection<Blog> Blogs { get; private set; } = [];
        public virtual BlogCategory? Parent { get; private set; }
    }
}
