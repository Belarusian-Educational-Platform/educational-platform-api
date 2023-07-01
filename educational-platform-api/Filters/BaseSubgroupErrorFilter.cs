using educational_platform_api.Exceptions;
using HotChocolate;

namespace educational_platform_api.Filters
{
    public class BaseSubgroupErrorFilter : IErrorFilter
    {
        public IError OnError(IError error)
        {
            if (error.Exception is not null && typeof(BaseSubgroupException).IsAssignableFrom(error.Exception.GetType()))
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
