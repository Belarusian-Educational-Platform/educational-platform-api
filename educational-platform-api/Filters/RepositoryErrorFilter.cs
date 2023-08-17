using educational_platform_api.Exceptions.RepositoryExceptions;

namespace educational_platform_api.Filters
{
    public class RepositoryErrorFilter : IErrorFilter
    {
        public IError OnError(IError error)
        {
            if (typeof(BaseRepositoryException).IsAssignableFrom(error.Exception.GetType()))
            {
                if (typeof(EntityNotFoundException).IsAssignableFrom(error.Exception.GetType()))
                {
                    return ProcessEntityNotFoundException(error);
                } 
                else if (typeof(EntityCreateException).IsAssignableFrom(error.Exception.GetType()))
                {
                    return ProcessEntityCreateException(error);
                }
                else if (typeof(EntityUpdateException).IsAssignableFrom(error.Exception.GetType()))
                {
                    return ProcessEntityUpdateException(error);
                }
                else if (typeof(EntityDeleteException).IsAssignableFrom(error.Exception.GetType()))
                {
                    return ProcessEntityDeleteException(error);
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

        private IError ProcessEntityNotFoundException(IError error)
        {
            EntityNotFoundException exception = (EntityNotFoundException) error.Exception!;
            return error.WithMessage(String.Format("{0}ByIdNotFoundException", exception.Entity));
        }

        private IError ProcessEntityCreateException(IError error)
        {
            EntityCreateException exception = (EntityCreateException)error.Exception!;
            return error.WithMessage(String.Format("{0}CreateException", exception.Entity));
        }

        private IError ProcessEntityUpdateException(IError error)
        {
            EntityUpdateException exception = (EntityUpdateException)error.Exception!;
            return error.WithMessage(String.Format("{0}UpdateException", exception.Entity));
        }

        private IError ProcessEntityDeleteException(IError error)
        {
            EntityDeleteException exception = (EntityDeleteException)error.Exception!;
            return error.WithMessage(String.Format("{0}DeleteException", exception.Entity));
        }
    }
}
