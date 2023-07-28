using System.Runtime.Serialization;

namespace educational_platform_api.Exceptions.RepositoryExceptions.EntityUpdateException
{
    public class ProfileUpdateException : BaseEntityUpdateException
    {
        public ProfileUpdateException()
        {
        }

        public ProfileUpdateException(string? message) : base(message)
        {
        }

        public ProfileUpdateException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected ProfileUpdateException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
