using educational_platform_api.Exceptions.BusinessLogicExceptions;

namespace educational_platform_api.Filters
{
    public class OrganizationErrorFilter : IErrorFilter
    {
        public IError OnError(IError error)
        {
            if ( typeof(BaseOrganizationException).IsAssignableFrom(error.Exception.GetType()))
            {
                return error.WithMessage("Exception inherits BaseOrganizationException");
            }
            else
            {
                return error;
            }
        }
    }
}
