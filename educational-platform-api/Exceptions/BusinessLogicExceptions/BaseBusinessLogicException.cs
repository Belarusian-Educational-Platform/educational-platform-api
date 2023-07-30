using System.Runtime.Serialization;

namespace educational_platform_api.Exceptions.BusinessLogicExceptions
{
    public class BaseBusinessLogicException : BaseException
    {
        public BaseBusinessLogicException()
        {
        }

        public BaseBusinessLogicException(string? message) : base(message)
        {
        }

        public BaseBusinessLogicException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected BaseBusinessLogicException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
