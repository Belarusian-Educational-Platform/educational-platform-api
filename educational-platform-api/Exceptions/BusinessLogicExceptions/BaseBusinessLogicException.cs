using System.Runtime.Serialization;

namespace educational_platform_api.Exceptions.BusinessLogicExceptions
{
    public class BaseBusinessLogicException : BaseException
    {
        public string Entity;

        public BaseBusinessLogicException(string entity)
        {
            Entity = entity;
        }

        public BaseBusinessLogicException(string entity, string? message) : base(message)
        {
            Entity = entity;
        }

        public BaseBusinessLogicException(string entity, string? message, Exception? innerException) : base(message, innerException)
        {
            Entity = entity;
        }

        protected BaseBusinessLogicException(string entity, SerializationInfo info, StreamingContext context) : base(info, context)
        {
            Entity = entity;
        }
    }
}
