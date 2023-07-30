using System.Runtime.Serialization;

namespace educational_platform_api.Exceptions.RepositoryExceptions.EntityUpdateException
{
    public class GroupUpdateException : BaseEntityUpdateException
    {
        public GroupUpdateException()
        {
        }

        public GroupUpdateException(string? message) : base(message)
        {
        }

        public GroupUpdateException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected GroupUpdateException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
