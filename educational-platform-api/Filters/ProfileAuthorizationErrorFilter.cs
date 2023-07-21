using educational_platform_api.Exceptions.BusinessLogicExceptions;
using educational_platform_api.Exceptions.ProfileAuthorizationExceptions;
using educational_platform_api.Exceptions.RepositoryExceptions.EnityNotFoundExceptions;

namespace educational_platform_api.Filters
{
    public class ProfileAuthorizationErrorFilter : IErrorFilter
    {
        public IError OnError(IError error)
        {
            if (typeof(BaseProfileAuthorizationException).IsAssignableFrom(error.Exception.GetType()))
            {
                if (typeof(JSONPermissionsParseException).IsAssignableFrom(error.Exception.GetType()))
                {
                    return processJSONPermissionsParseException(error);
                }
                else if (typeof(ProvidedAndRequestedPermissionsMismatchException).IsAssignableFrom(error.Exception.GetType()))
                {
                    return processProvidedAndRequestedPermissionsMismatch(error);
                }
                else
                {
                    return error.WithMessage("Unexpected BaseProfileAuthorizationException");
                }
            }
            else
            {
                return error;
            }
        }
        private IError processJSONPermissionsParseException(IError error)
        {
                return error.WithMessage("processJSONPermissionsParseException");
        }
        private IError processProvidedAndRequestedPermissionsMismatch(IError error)
        {
                return error.WithMessage("processProvidedAndRequestedPermissionsMismatch");
        }
    }
}
