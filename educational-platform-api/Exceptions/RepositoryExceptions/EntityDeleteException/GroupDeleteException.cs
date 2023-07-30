using System.Runtime.Serialization;

namespace educational_platform_api.Exceptions.RepositoryExceptions.EntityDeleteException
{
    public class GroupDeleteException : BaseEntityDeleteException
    {
        public GroupDeleteException()
        {
        }

        public GroupDeleteException(string? message) : base(message)
        {
        }

        public GroupDeleteException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected GroupDeleteException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
