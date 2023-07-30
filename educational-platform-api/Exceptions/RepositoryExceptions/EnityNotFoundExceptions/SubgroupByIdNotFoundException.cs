using System.Runtime.Serialization;

namespace educational_platform_api.Exceptions.RepositoryExceptions.EnityNotFoundExceptions
{
    public class SubgroupByIdNotFoundException : BaseEntityNotFoundException
    {
        public SubgroupByIdNotFoundException()
        {
        }

        public SubgroupByIdNotFoundException(string? message) : base(message)
        {
        }

        public SubgroupByIdNotFoundException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected SubgroupByIdNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
