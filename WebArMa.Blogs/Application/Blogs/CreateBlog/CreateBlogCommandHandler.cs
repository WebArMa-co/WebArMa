using FluentValidation;
using Microsoft.EntityFrameworkCore;
using WebArMa.Application.Contexts;
using WebArMa.Application.Interfaces.Mediator;
using WebArMa.Blogs.Domain.Blogs.Entities;
using WebArMa.Blogs.Domain.Exceptions;

namespace WebArMa.Blogs.Application.Blogs.CreateBlog
{
    public class CreateBlogCommandHandler(IWebArMaDbContext dbContext) : IWebArMaCommandHandler<CreateBlogCommand, Guid>
    {
        public async ValueTask<Guid> Handle(CreateBlogCommand request, CancellationToken cancellationToken)
        {
            var slug = request.Slug.Trim().Replace(" ", "-");

            var slugExists = await dbContext.Set<Blog>().AnyAsync(x => x.Slug == slug, cancellationToken);

            if (slugExists)
            {
                throw new AlreadyExistsException("پیوند انتخاب شده از قبل وجود دارد", nameof(Blog.Slug));
            }

            var blogCategories = await dbContext.Set<BlogCategory>().Where(x => request.BlogCategoryIds.Contains(x.Guid)).ToListAsync(cancellationToken);

            if (blogCategories.Count != request.BlogCategoryIds.Distinct().Count())
            {
                throw new NotFoundException("یک یا چند دسته‌بندی انتخاب شده یافت نشد.", nameof(BlogCategory));
            }

            var blog = Blog.Create(
                title: request.Title,
                slug: slug,
                content: request.Content,
                status: request.Status,
                authorId: currentUser.Guid,
                metaDescription: request.MetaDescription,
                publishedAt: request.PublishedAt,
                metaTitle: request.MetaTitle,
                canonicalUrl: request.CanonicalUrl,
                ogImage: request.OgImage,
                coverImage: request.CoverImage);

            foreach (var category in blogCategories)
            {
                blog.AddCategory(category);
            }

            await dbContext.Set<Blog>().AddAsync(blog, cancellationToken);
            await dbContext.SaveChangesAsync(cancellationToken);

            return blog.Guid;
        }
    }
}
