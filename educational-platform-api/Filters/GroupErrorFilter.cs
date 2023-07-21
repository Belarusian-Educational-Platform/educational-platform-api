using educational_platform_api.Exceptions.BusinessLogicExceptions;

namespace educational_platform_api.Filters
{
    public class GroupErrorFilter : IErrorFilter
    {
        public IError OnError(IError error)
        {
            if (typeof(BaseGroupException).IsAssignableFrom(error.Exception.GetType()))
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
