using System.Runtime.Serialization;

namespace api.Exceptions.RepositoryExceptions
{
    public class EntityNotFoundException : BaseRepositoryException
    {
        public EntityNotFoundException(string entity) : base(entity)
        {
        }

        public EntityNotFoundException(string entity, string? message) : base(entity, message)
        {
        }

        public EntityNotFoundException(string entity, string? message, Exception? innerException) : base(entity, message, innerException)
        {
        }

        protected EntityNotFoundException(string entity, SerializationInfo info, StreamingContext context) : base(entity, info, context)
        {
        }
    }
}
