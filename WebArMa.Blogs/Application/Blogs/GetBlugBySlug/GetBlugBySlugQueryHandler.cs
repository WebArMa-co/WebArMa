using Mapster;
using Microsoft.EntityFrameworkCore;
using WebArMa.Application.Contexts;
using WebArMa.Application.Interfaces.Mediator;
using WebArMa.Application.Mappings;
using WebArMa.Blogs.Application.Blogs.Dtos;
using WebArMa.Blogs.Domain.Blogs.Entities;
using WebArMa.Blogs.Domain.Exceptions;

namespace WebArMa.Blogs.Application.Blogs.GetBlugBySlug
{
    public class GetBlugBySlugQueryHandler(IWebArMaDbContext webArMaDbContext, WebArMaTypeAdapterConfig config) : IWebArMaQueryHandler<GetBlugBySlugQuery, BlogDto>
    {
        public async ValueTask<BlogDto> Handle(GetBlugBySlugQuery query, CancellationToken cancellationToken)
        {
            return await webArMaDbContext.Set<Blog>().ProjectToType<BlogDto>(config).FirstOrDefaultAsync(b => b.Slug == query.Slug, cancellationToken: cancellationToken) ?? throw new NotFoundException("مطلب یافت نشد");
        }
    }
}
