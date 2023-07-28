using System.Runtime.Serialization;

namespace educational_platform_api.Exceptions.RepositoryExceptions
{
    public class BaseRepositoryException : BaseException
    {
        public BaseRepositoryException()
        {
        }

        public BaseRepositoryException(string? message) : base(message)
        {
        }

        public BaseRepositoryException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected BaseRepositoryException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
