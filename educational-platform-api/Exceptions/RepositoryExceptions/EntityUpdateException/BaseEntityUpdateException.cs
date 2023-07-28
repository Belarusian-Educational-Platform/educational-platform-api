using System.Runtime.Serialization;

namespace educational_platform_api.Exceptions.RepositoryExceptions.EntityUpdateException
{
    public class BaseEntityUpdateException : BaseRepositoryException
    {
        public BaseEntityUpdateException()
        {
        }

        public BaseEntityUpdateException(string? message) : base(message)
        {
        }

        public BaseEntityUpdateException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected BaseEntityUpdateException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
