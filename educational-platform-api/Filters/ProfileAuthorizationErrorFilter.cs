using educational_platform_api.Exceptions.ProfileAuthorizationExceptions;

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
                    return ProcessJSONPermissionsParseException(error);
                }
                else if (typeof(ProvidedAndRequestedPermissionsMismatchException).IsAssignableFrom(error.Exception.GetType()))
                {
                    return ProcessProvidedAndRequestedPermissionsMismatch(error);
                }else if(typeof(RequestedPolicyNotExistsException).IsAssignableFrom(error.Exception.GetType()))
                {
                    return ProcessRequestedPolicyDoesNotExistsException(error);
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
        private IError ProcessJSONPermissionsParseException(IError error)
        {
            return error.WithMessage("processJSONPermissionsParseException");
        }
        private IError ProcessProvidedAndRequestedPermissionsMismatch(IError error)
        {
            return error.WithMessage("processProvidedAndRequestedPermissionsMismatch");
        }
        private IError ProcessRequestedPolicyDoesNotExistsException(IError error)
        {
            return error.WithMessage("processRequestedPolicyDoesNotExistsException");
        }
    }
}
