using System.Runtime.Serialization;

namespace educational_platform_api.Exceptions.RepositoryExceptions
{
    public class BaseRepositoryException : BaseException
    {
        public string Entity;

        public BaseRepositoryException(string entity)
        {
            Entity = entity;
        }

        public BaseRepositoryException(string entity, string? message) : base(message)
        {
            Entity = entity;
        }

        public BaseRepositoryException(string entity, string? message, Exception? innerException) : base(message, innerException)
        {
            Entity = entity;
        }

        protected BaseRepositoryException(string entity, SerializationInfo info, StreamingContext context) : base(info, context)
        {
            Entity = entity;
        }
    }
}
