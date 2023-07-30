using System.Runtime.Serialization;

namespace educational_platform_api.Exceptions.ProfileAuthorizationExceptions
{
    public class JSONPermissionsParseException : BaseProfileAuthorizationException
    {
        public JSONPermissionsParseException()
        {
        }

        public JSONPermissionsParseException(string? message) : base(message)
        {
        }

        public JSONPermissionsParseException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected JSONPermissionsParseException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
