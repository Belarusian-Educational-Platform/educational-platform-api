using educational_platform_api.Exceptions;
using HotChocolate;

namespace educational_platform_api.Filters
{
    public class SubgroupErrorFilter : IErrorFilter
    {
        public IError OnError(IError error)
        {
            if (typeof(BaseSubgroupException).IsAssignableFrom(error.Exception.GetType()))
            {
                return error.WithMessage("Exception inherits BaseSubgroupException");
            }
            else
            {
                return error;
            }
        }
    }
}
