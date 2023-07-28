using System.Runtime.Serialization;

namespace educational_platform_api.Exceptions.RepositoryExceptions.EntityDeleteException
{
    public class BaseEntityDeleteException : BaseRepositoryException
    {
        public BaseEntityDeleteException()
        {
        }

        public BaseEntityDeleteException(string? message) : base(message)
        {
        }

        public BaseEntityDeleteException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected BaseEntityDeleteException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
