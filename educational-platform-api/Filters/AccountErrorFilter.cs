using HotChocolate;
using educational_platform_api.Exceptions;

namespace educational_platform_api.Filters
{
    public class AccountErrorFilter : IErrorFilter
    {
        public IError OnError(IError error)
        {
            if (typeof(BaseAccountException).IsAssignableFrom(error.Exception.GetType()))
            {
                return error.WithMessage("Exception inherits BaseAccountException");
            }
            else
            {
                return error;
            }
        }
    }
}
