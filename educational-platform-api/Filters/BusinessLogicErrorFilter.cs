using educational_platform_api.Exceptions.BusinessLogicExceptions;

namespace educational_platform_api.Filters
{
    public class BusinessLogicErrorFilter : IErrorFilter
    {
        public IError OnError(IError error)
        {
            if (typeof(BaseBusinessLogicException).IsAssignableFrom(error.Exception.GetType()))
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
