using Mediator;
using Microsoft.EntityFrameworkCore;
using WebArMa.Application.Contexts;
using WebArMa.Application.Interfaces.Mediator;
using WebArMa.Blogs.Domain.Blogs.Entities;
using WebArMa.Blogs.Domain.Exceptions;

namespace WebArMa.Blogs.Application.Blogs.DeleteBlog
{
    public class DeleteBlogCommandHandler(IWebArMaDbContext dbContext) : IWebArMaCommandHandler<DeleteBlogCommand>
    {
        public async ValueTask<Unit> Handle(DeleteBlogCommand request, CancellationToken cancellationToken)
        {
            var blog = await dbContext.Set<Blog>().FirstOrDefaultAsync(b => b.Guid == request.Guid, cancellationToken: cancellationToken) ?? throw new NotFoundException("مطلب یافت نشد");
            dbContext.Set<Blog>().Remove(blog);
            await dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
