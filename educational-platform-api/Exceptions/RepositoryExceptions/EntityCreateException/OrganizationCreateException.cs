using System.Runtime.Serialization;

namespace educational_platform_api.Exceptions.RepositoryExceptions.EntityCreateException
{
    public class OrganizationCreateException : BaseEntityCreateException
    {
        public OrganizationCreateException()
        {
        }

        public OrganizationCreateException(string? message) : base(message)
        {
        }

        public OrganizationCreateException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected OrganizationCreateException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
