using System.Runtime.Serialization;

namespace ProfileAuthorization.Exceptions
{
    public class ProvidedAndRequestedPermissionsMismatchException : BaseProfileAuthorizationException
    {
        public ProvidedAndRequestedPermissionsMismatchException()
        {
        }

        public ProvidedAndRequestedPermissionsMismatchException(string? message) : base(message)
        {
        }

        public ProvidedAndRequestedPermissionsMismatchException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected ProvidedAndRequestedPermissionsMismatchException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
