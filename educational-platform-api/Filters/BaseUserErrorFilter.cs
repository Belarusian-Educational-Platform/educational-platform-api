using educational_platform_api.Exceptions;
using HotChocolate;

namespace educational_platform_api.Filters
{
    public class BaseUserErrorFilter : IErrorFilter
    {
        public IError OnError(IError error)
        {
            if (typeof(BaseUserException).IsAssignableFrom(error.Exception.GetType()))
            {
                return error.WithMessage("Exception inhearts BaseUserException");
            }
            else
            {
                return error;
            }
        }
    }
}
