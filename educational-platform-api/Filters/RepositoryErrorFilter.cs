using educational_platform_api.Exceptions.RepositoryExceptions;

namespace educational_platform_api.Filters
{
    public class RepositoryErrorFilter : IErrorFilter
    {
        public IError OnError(IError error)
        {
            if (typeof(BaseRepositoryException).IsAssignableFrom(error.Exception.GetType()))
            {
                return error;
            }
            else
            {
                return error;
            }
        }
    }
}
