using FluentValidation;
using Mapster;
using Microsoft.EntityFrameworkCore;
using WebArMa.Application.Contexts;
using WebArMa.Application.Dtos;
using WebArMa.Application.Interfaces.Mediator;
using WebArMa.Application.Mappings;
using WebArMa.Blogs.Application.Blogs.Dtos;
using WebArMa.Blogs.Domain.Blogs.Entities;
using WebArMa.Common.Extensions;

namespace WebArMa.Blogs.Application.Blogs.GetBlogList
{
    public class GetBlogListCommandHandler(IWebArMaDbContext dbContext, WebArMaTypeAdapterConfig config) : IWebArMaCommandHandler<GetBlogListCommand, PagedResult<BlogDto>>
    {
        public async ValueTask<PagedResult<BlogDto>> Handle(GetBlogListCommand request, CancellationToken cancellationToken)
        {
            var query = dbContext.Set<Blog>().AsNoTracking().AsQueryable();

            if (!string.IsNullOrWhiteSpace(request.Search))
            {
                var search = request.Search.Trim();
                query = query.Where(b => b.Title.Contains(search) || b.Slug.Contains(search) || b.MetaDescription!.Contains(search));
            }

            if (request.Status.HasValue)
            {
                query = query.Where(b => b.Status == request.Status.Value);
            }

            var totalCount = await query.CountAsync(cancellationToken: cancellationToken);
            query = query.Paginate(request.PageNumber, request.PageSize);
            var blogs = await query.ProjectToType<BlogDto>(config).ToListAsync(cancellationToken);

            return new PagedResult<BlogDto>(blogs, totalCount, request.PageNumber, request.PageSize);
        }
    }
}
