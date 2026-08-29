using WebArMa.Application.Interfaces.Mediator;
using WebArMa.Blogs.Application.Blogs.Dtos;

namespace WebArMa.Blogs.Application.Blogs.GetBlugBySlug
{
    public class GetBlugBySlugQuery(string slug) : IWebArMaQuery<BlogDto>
    {
        public string Slug { get; private set; } = slug;
    }
}
