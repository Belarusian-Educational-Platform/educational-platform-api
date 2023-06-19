using educational_platform_api.Exceptions;

namespace educational_platform_api.Filters
{
    public class GlobalErrorFilter : IErrorFilter
    {
        public IError OnError(IError error)
        {
            BaseException exception = (BaseException) error.Exception;
            IError response = error.WithException(exception);

            return response;
        }
    }
}
