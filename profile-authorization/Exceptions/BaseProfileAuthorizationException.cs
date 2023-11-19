using System.Runtime.Serialization;

namespace ProfileAuthorization.Exceptions
{
    public class BaseProfileAuthorizationException : Exception
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
