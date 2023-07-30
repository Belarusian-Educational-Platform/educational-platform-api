using System.Runtime.Serialization;

namespace educational_platform_api.Exceptions.RepositoryExceptions.EnityNotFoundExceptions
{
    public class OrganizationByIdNotFoundException : BaseEntityNotFoundException
    {
        public OrganizationByIdNotFoundException()
        {
        }

        public OrganizationByIdNotFoundException(string? message) : base(message)
        {
        }

        public OrganizationByIdNotFoundException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected OrganizationByIdNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
