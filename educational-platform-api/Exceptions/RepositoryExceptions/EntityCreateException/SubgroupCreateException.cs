using System.Runtime.Serialization;

namespace educational_platform_api.Exceptions.RepositoryExceptions.EntityCreateException
{
    public class SubgroupCreateException : BaseEntityCreateException
    {
        public SubgroupCreateException()
        {
        }

        public SubgroupCreateException(string? message) : base(message)
        {
        }

        public SubgroupCreateException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected SubgroupCreateException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
