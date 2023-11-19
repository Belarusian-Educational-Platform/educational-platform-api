using System.Runtime.Serialization;

namespace api.Exceptions.RepositoryExceptions
{
    public class EntityDeleteException : BaseRepositoryException
    {
        public EntityDeleteException(string entity) : base(entity)
        {
        }

        public EntityDeleteException(string entity, string? message) : base(entity, message)
        {
        }

        public EntityDeleteException(string entity, string? message, Exception? innerException) : base(entity, message, innerException)
        {
        }

        protected EntityDeleteException(string entity, SerializationInfo info, StreamingContext context) : base(entity, info, context)
        {
        }
    }
}
