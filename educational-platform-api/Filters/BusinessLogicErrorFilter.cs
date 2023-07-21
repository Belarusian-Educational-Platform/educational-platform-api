using educational_platform_api.Exceptions.BusinessLogicExceptions;

namespace educational_platform_api.Filters
{
    public class BusinessLogicErrorFilter : IErrorFilter
    {
        public IError OnError(IError error)
        {
            if (typeof(BaseBusinessLogicException).IsAssignableFrom(error.Exception.GetType()))
            {
                if (typeof(BaseAccountException).IsAssignableFrom(error.Exception.GetType()))
                {
                    return ProcessAccountException(error);
                }else if (typeof(BaseProfileException).IsAssignableFrom(error.Exception.GetType()))
                {
                    return ProcessProfileException(error);
                }
                else if (typeof(BaseOrganizationException).IsAssignableFrom(error.Exception.GetType()))
                {
                    return ProcessOrganizationException(error);
                }
                else if (typeof(BaseGroupException).IsAssignableFrom(error.Exception.GetType()))
                {
                    return ProcessGroupException(error);
                }
                else if (typeof(BaseSubgroupException).IsAssignableFrom(error.Exception.GetType()))
                {
                    return ProcessSubgroupException(error);
                }
                else
                {
                    return error;
                }
            }
            else
            {
                return error;
            }
        }
        private IError ProcessProfileException(IError error)
        {
            return error.WithMessage("ProcessProfileExceptions");
        }
        private IError ProcessAccountException(IError error)
        {
            return error.WithMessage("ProcessAccountException");
        }
        private IError ProcessOrganizationException(IError error)
        {
            return error.WithMessage("ProcessOrganizationException");
        }
        private IError ProcessGroupException(IError error)
        {
            return error.WithMessage("ProcessGroupException");
        }
        private IError ProcessSubgroupException(IError error)
        {
            return error.WithMessage("ProcessSubgroupException");
        }
    }
}
