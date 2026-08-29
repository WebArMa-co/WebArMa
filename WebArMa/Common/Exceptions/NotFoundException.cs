namespace WebArMa.Blogs.Domain.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string entity, string? message = null)
        {

        }

        public NotFoundException(string? message = null)
        {

        }

        public NotFoundException()
        {

        }
    }
}
