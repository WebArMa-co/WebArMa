using FluentValidation;
using Microsoft.EntityFrameworkCore;
using WebArMa.Application.Contexts;
using WebArMa.Application.Interfaces.Mediator;
using WebArMa.Blogs.Domain.Blogs.Entities;
using WebArMa.Blogs.Domain.Exceptions;

namespace WebArMa.Blogs.Application.Blogs.CreateBlog
{
    public class UpdateBlogCommandHandler(IWebArMaDbContext dbContext) : IWebArMaCommandHandler<UpdateBlogCommand, Guid>
    {
        public async ValueTask<Guid> Handle(UpdateBlogCommand request, CancellationToken cancellationToken)
        {
            var slug = request.Slug.Trim().Replace(" ", "-");
            var checkSlugExists = await dbContext.Set<Blog>().AnyAsync(b => b.Guid != request.Guid && b.Slug == request.Slug, cancellationToken: cancellationToken);

            if (checkSlugExists)
            {
                throw new AlreadyExistsException(nameof(Blog.Slug), "پیوند انتخاب شده از قبل وجود دارد");
            }

            var blog = await dbContext.Set<Blog>().FirstOrDefaultAsync(b => b.Guid == request.Guid, cancellationToken: cancellationToken) ?? throw new NotFoundException("مطلب یافت نشد");
            var blogCategories = await dbContext.Set<BlogCategory>().Where(b => request.BlogCategoryIds.Contains(b.Guid)).ToListAsync(cancellationToken: cancellationToken);

            //TO DO

            Blog.Update(blog, request.Title, request.Slug, request.Content, blogCategories, request.Status, 0, request.MetaDescription, request.PublishedAt, request.MetaTitle, request.CanonicalUrl, request.OgImage, request.CoverImage);

            await dbContext.Set<Blog>().AddAsync(blog, cancellationToken);
            await dbContext.SaveChangesAsync(cancellationToken);
            return blog.Guid;
        }
    }
}
