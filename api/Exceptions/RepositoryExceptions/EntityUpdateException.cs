using System.Runtime.Serialization;

namespace api.Exceptions.RepositoryExceptions
{
    public class EntityUpdateException : BaseRepositoryException
    {
        public EntityUpdateException(string entity) : base(entity)
        {
        }

        public EntityUpdateException(string entity, string? message) : base(entity, message)
        {
        }

        public EntityUpdateException(string entity, string? message, Exception? innerException) : base(entity, message, innerException)
        {
        }

        protected EntityUpdateException(string entity, SerializationInfo info, StreamingContext context) : base(entity, info, context)
        {
        }
    }
}
