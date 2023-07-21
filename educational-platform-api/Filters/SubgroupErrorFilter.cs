using educational_platform_api.Exceptions.BusinessLogicExceptions;

namespace educational_platform_api.Filters
{
    public class SubgroupErrorFilter : IErrorFilter
    {
        public IError OnError(IError error)
        {
            if (typeof(BaseSubgroupException).IsAssignableFrom(error.Exception.GetType()))
            {
                return error.WithMessage("Exception inhearts BaseSubgroupException");
            }
            else
            {
                return error;
            }
        }
    }
}
