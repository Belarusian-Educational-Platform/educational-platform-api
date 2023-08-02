using System.Runtime.Serialization;

namespace educational_platform_api.Exceptions.ProfileAuthorizationExceptions
{
    public class ProvidedEntitiesOrganizationNotCorrespondsException : BaseProfileAuthorizationException
    {
        public ProvidedEntitiesOrganizationNotCorrespondsException()
        {
        }

        public ProvidedEntitiesOrganizationNotCorrespondsException(string? message) : base(message)
        {
        }

        public ProvidedEntitiesOrganizationNotCorrespondsException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected ProvidedEntitiesOrganizationNotCorrespondsException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
