using System.Runtime.Serialization;

namespace ProfileAuthorization.Exceptions
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
