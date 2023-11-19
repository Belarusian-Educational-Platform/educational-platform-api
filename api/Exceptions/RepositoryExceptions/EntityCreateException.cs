using System.Runtime.Serialization;

namespace api.Exceptions.RepositoryExceptions
{
    public class EntityCreateException : BaseRepositoryException
    {
        public EntityCreateException(string entity) : base(entity)
        {
        }

        public EntityCreateException(string entity, string? message) : base(entity, message)
        {
        }

        public EntityCreateException(string entity, string? message, Exception? innerException) : base(entity, message, innerException)
        {
        }

        protected EntityCreateException(string entity, SerializationInfo info, StreamingContext context) : base(entity, info, context)
        {
        }
    }
}
