using System.Runtime.Serialization;

namespace educational_platform_api.Exceptions.RepositoryExceptions.EntityCreateException
{
    public class ProfileCreateException : BaseEntityCreateException
    {
        public ProfileCreateException()
        {
        }

        public ProfileCreateException(string? message) : base(message)
        {
        }

        public ProfileCreateException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected ProfileCreateException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
