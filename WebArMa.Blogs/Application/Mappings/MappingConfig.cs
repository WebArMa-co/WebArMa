using WebArMa.Application.Mappings;
using WebArMa.Blogs.Application.Blogs.Dtos;
using WebArMa.Blogs.Domain.Blogs.Entities;

namespace WebArMa.Blogs.Application.Mappings
{
    public class BlogMapping : IWebArMaMapperConfiguration
    {
        public void Register(WebArMaTypeAdapterConfig config)
        {
            config.NewConfig<Blog, BlogDto>();
        }
    }
}
