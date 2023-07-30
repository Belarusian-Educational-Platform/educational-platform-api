using System.Runtime.Serialization;

namespace educational_platform_api.Exceptions.RepositoryExceptions.EntityUpdateException
{
    public class SubgroupUpdateException : BaseEntityUpdateException
    {
        public SubgroupUpdateException()
        {
        }

        public SubgroupUpdateException(string? message) : base(message)
        {
        }

        public SubgroupUpdateException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected SubgroupUpdateException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
