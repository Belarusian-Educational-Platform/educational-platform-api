using System.Runtime.Serialization;

namespace educational_platform_api.Exceptions.RepositoryExceptions.EntityCreateException
{
    public class BaseEntityCreateException : BaseRepositoryException
    {
        public BaseEntityCreateException()
        {
        }

        public BaseEntityCreateException(string? message) : base(message)
        {
        }

        public BaseEntityCreateException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected BaseEntityCreateException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
