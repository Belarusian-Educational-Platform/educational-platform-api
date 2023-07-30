using System.Runtime.Serialization;

namespace educational_platform_api.Exceptions.RepositoryExceptions.EnityNotFoundExceptions
{
    public class GroupByIdNotFoundException : BaseEntityNotFoundException
    {
        public GroupByIdNotFoundException()
        {
        }

        public GroupByIdNotFoundException(string? message) : base(message)
        {
        }

        public GroupByIdNotFoundException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected GroupByIdNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
