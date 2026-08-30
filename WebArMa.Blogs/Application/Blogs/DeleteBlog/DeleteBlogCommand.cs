using WebArMa.Application.Interfaces.Mediator;

namespace WebArMa.Blogs.Application.Blogs.DeleteBlog
{
    public sealed record DeleteBlogCommand(Guid Guid) : IWebArMaCommand;
}
