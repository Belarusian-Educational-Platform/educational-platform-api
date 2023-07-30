using System.Runtime.Serialization;

namespace educational_platform_api.Exceptions.RepositoryExceptions.EntityDeleteException
{
    public class OrganizationDeleteException : BaseEntityDeleteException
    {
        public OrganizationDeleteException()
        {
        }

        public OrganizationDeleteException(string? message) : base(message)
        {
        }

        public OrganizationDeleteException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected OrganizationDeleteException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
