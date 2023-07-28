using System.Runtime.Serialization;

namespace educational_platform_api.Exceptions.RepositoryExceptions.EnityNotFoundExceptions
{
    public class ProfileByIdNotFoundException : BaseEntityNotFoundException
    {
        public ProfileByIdNotFoundException()
        {
        }

        public ProfileByIdNotFoundException(string? message) : base(message)
        {
        }

        public ProfileByIdNotFoundException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected ProfileByIdNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
