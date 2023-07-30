using System.Runtime.Serialization;

namespace educational_platform_api.Exceptions.RepositoryExceptions.EntityCreateException
{
    public class GroupCreateException : BaseEntityCreateException
    {
        public GroupCreateException()
        {
        }

        public GroupCreateException(string? message) : base(message)
        {
        }

        public GroupCreateException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected GroupCreateException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
