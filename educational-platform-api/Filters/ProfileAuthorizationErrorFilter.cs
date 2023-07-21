using educational_platform_api.Exceptions.BusinessLogicExceptions;
using educational_platform_api.Exceptions.ProfileAuthorizationExceptions;

namespace educational_platform_api.Filters
{
    public class ProfileAuthorizationErrorFilter : IErrorFilter
    {
        public IError OnError(IError error)
        {
            if (typeof(BaseProfileAuthorizationException).IsAssignableFrom(error.Exception.GetType()))
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
