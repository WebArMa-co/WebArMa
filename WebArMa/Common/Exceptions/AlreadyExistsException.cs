namespace WebArMa.Blogs.Domain.Exceptions
{
    public class AlreadyExistsException : Exception
    {
        public AlreadyExistsException(string entity, string? message = null)
        {

        }

        public AlreadyExistsException(string? message = null)
        {

        }

        public AlreadyExistsException()
        {

        }
    }
}
