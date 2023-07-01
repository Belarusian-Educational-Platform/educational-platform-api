using educational_platform_api.Exceptions;
using HotChocolate;

namespace educational_platform_api.Filters
{
    public class BaseGroupErrorFilter : IErrorFilter
    {
        public IError OnError(IError error)
        {
            if (error.Exception is not null && typeof(BaseGroupException).IsAssignableFrom(error.Exception.GetType()))
            {
                return error.WithMessage("Exception inhearts BaseGroupException");
            }
            else
            {
                return error;
            }
        }
    }
}
