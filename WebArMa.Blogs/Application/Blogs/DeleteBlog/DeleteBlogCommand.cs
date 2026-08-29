using WebArMa.Application.Interfaces.Mediator;

namespace WebArMa.Blogs.Application.Blogs.DeleteBlog
{
    public class DeleteBlogCommand(Guid guid) : IWebArMaCommand
    {
        public Guid Guid { get; set; } = guid;
    }
}
