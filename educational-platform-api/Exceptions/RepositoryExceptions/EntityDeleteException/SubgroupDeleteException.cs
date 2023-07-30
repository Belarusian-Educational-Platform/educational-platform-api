using System.Runtime.Serialization;

namespace educational_platform_api.Exceptions.RepositoryExceptions.EntityDeleteException
{
    public class SubgroupDeleteException : BaseEntityDeleteException
    {
        public SubgroupDeleteException()
        {
        }

        public SubgroupDeleteException(string? message) : base(message)
        {
        }

        public SubgroupDeleteException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected SubgroupDeleteException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
