using System.Runtime.Serialization;

namespace educational_platform_api.Exceptions.BusinessLogicExceptions
{
    public class EntityValidationException : BaseBusinessLogicException
    {
        public EntityValidationException(string entity) : base(entity)
        {
        }

        public EntityValidationException(string entity, string? message) : base(entity, message)
        {
        }

        public EntityValidationException(string entity, string? message, Exception? innerException) : base(entity, message, innerException)
        {
        }

        protected EntityValidationException(string entity, SerializationInfo info, StreamingContext context) : base(entity, info, context)
        {
        }
    }
}
