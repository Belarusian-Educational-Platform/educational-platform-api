using educational_platform_api.Exceptions.RepositoryExceptions;
using educational_platform_api.Exceptions.RepositoryExceptions.EnityNotFoundExceptions;

namespace educational_platform_api.Filters
{
    public class RepositoryErrorFilter : IErrorFilter
    {
        public IError OnError(IError error)
        {
            if (typeof(BaseRepositoryException).IsAssignableFrom(error.Exception.GetType()))
            {
                if (typeof(BaseEntityNotFoundException).IsAssignableFrom(error.Exception.GetType()))
                {
                    return processEntityNotFoundException(error);
                }
                else
                {
                    return error.WithMessage("Unexpected BaseRepositoryException");
                }
            }
            else
            {
                return error;
            }
        }

        private IError processEntityNotFoundException(IError error)
        {
            if (typeof(ProfileByIdNotFoundException).IsAssignableFrom(error.Exception.GetType()))
            {
                return error.WithMessage("ProfileByIdNotFoundException");
            }
            else
            {
                return error.WithMessage("Unexpected EntityNotFoundException");
            }
        }
    }
}
