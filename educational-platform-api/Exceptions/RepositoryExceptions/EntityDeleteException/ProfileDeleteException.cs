using educational_platform_api.Exceptions.RepositoryExceptions.EntityDeleteException;
using System.Runtime.Serialization;

namespace educational_platform_api.Exceptions.RepositoryExceptions.EntityDeleteException
{
    public class ProfileDeleteException : BaseEntityDeleteException
    {
        public ProfileDeleteException()
        {
        }

        public ProfileDeleteException(string? message) : base(message)
        {
        }

        public ProfileDeleteException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected ProfileDeleteException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
