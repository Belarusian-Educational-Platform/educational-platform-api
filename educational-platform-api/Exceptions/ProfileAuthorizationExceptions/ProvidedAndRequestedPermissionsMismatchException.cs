using System.Runtime.Serialization;

namespace educational_platform_api.Exceptions.ProfileAuthorizationExceptions
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
