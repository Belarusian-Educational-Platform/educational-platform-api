using System.Runtime.Serialization;

namespace educational_platform_api.Exceptions.RepositoryExceptions.EnityNotFoundExceptions
{
    public class BaseEntityNotFoundException : BaseRepositoryException
    {
        public BaseEntityNotFoundException()
        {
        }

        public BaseEntityNotFoundException(string? message) : base(message)
        {
        }

        public BaseEntityNotFoundException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected BaseEntityNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
