using WebArMa.Application.Interfaces.Mediator;
using WebArMa.Blogs.Application.Blogs.Dtos;

namespace WebArMa.Blogs.Application.Blogs.GetBlugBySlug
{
    public sealed record GetBlogBySlugQuery(string Slug) : IWebArMaQuery<BlogDto>;
}
