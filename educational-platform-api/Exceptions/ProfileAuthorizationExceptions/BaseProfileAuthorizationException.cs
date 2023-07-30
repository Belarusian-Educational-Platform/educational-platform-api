using System.Runtime.Serialization;

namespace educational_platform_api.Exceptions.ProfileAuthorizationExceptions
{
    public class BaseProfileAuthorizationException : BaseException
    {
        public BaseProfileAuthorizationException()
        {
        }

        public BaseProfileAuthorizationException(string? message) : base(message)
        {
        }

        public BaseProfileAuthorizationException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected BaseProfileAuthorizationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
