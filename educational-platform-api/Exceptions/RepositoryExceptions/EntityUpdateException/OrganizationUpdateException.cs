using System.Runtime.Serialization;

namespace educational_platform_api.Exceptions.RepositoryExceptions.EntityUpdateException
{
    public class OrganizationUpdateException : BaseEntityUpdateException
    {
        public OrganizationUpdateException()
        {
        }

        public OrganizationUpdateException(string? message) : base(message)
        {
        }

        public OrganizationUpdateException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected OrganizationUpdateException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
