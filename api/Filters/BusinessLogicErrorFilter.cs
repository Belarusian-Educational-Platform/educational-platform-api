using api.Exceptions.BusinessLogicExceptions;

namespace api.Filters
{
    public class BusinessLogicErrorFilter : IErrorFilter
    {
        public IError OnError(IError error)
        {
            if (typeof(BaseBusinessLogicException).IsAssignableFrom(error.Exception.GetType()))
            {               
                return error.WithMessage("BusinessLogicException");
            }
            else
            {
                return error;
            }
        }
    }
}
