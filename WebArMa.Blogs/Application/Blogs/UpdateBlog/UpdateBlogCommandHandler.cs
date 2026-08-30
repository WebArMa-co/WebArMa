using FluentValidation;
using Microsoft.EntityFrameworkCore;
using WebArMa.Application.Contexts;
using WebArMa.Application.Interfaces.Mediator;
using WebArMa.Blogs.Domain.Blogs.Entities;
using WebArMa.Blogs.Domain.Exceptions;

namespace WebArMa.Blogs.Application.Blogs.UpdateBlog
{
    public sealed class UpdateBlogCommandHandler(IWebArMaDbContext dbContext)
        : IWebArMaCommandHandler<UpdateBlogCommand, Guid>
    {
        public async ValueTask<Guid> Handle(
            UpdateBlogCommand request,
            CancellationToken cancellationToken)
        {
            var slug = request.Slug.Trim().Replace(" ", "-");

            var slugExists = await dbContext
                .Set<Blog>()
                .AnyAsync(
                    x => x.Guid != request.Guid &&
                         x.Slug == slug,
                    cancellationToken);

            if (slugExists)
            {
                throw new AlreadyExistsException(
                    nameof(Blog.Slug),
                    "پیوند انتخاب شده از قبل وجود دارد");
            }

            var blog = await dbContext
                .Set<Blog>()
                .FirstOrDefaultAsync(
                    x => x.Guid == request.Guid,
                    cancellationToken)
                ?? throw new NotFoundException("مطلب یافت نشد");

            var blogCategories = await dbContext
                .Set<BlogCategory>()
                .Where(x => request.BlogCategoryIds.Contains(x.Guid))
                .ToListAsync(cancellationToken);

            if (blogCategories.Count != request.BlogCategoryIds.Distinct().Count())
            {
                throw new NotFoundException(
                    nameof(BlogCategory),
                    "یک یا چند دسته‌بندی انتخاب شده یافت نشد.");
            }

            blog.Update(
                title: request.Title,
                slug: slug,
                content: request.Content,
                status: request.Status,
                authorId: blog.AuthorId,
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

            await dbContext.SaveChangesAsync(cancellationToken);

            return blog.Guid;
        }
    }
}
