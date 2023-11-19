using HotChocolate;

namespace api.Filters
{
    public class ErrorWithNullExceptionFilter : IErrorFilter
    {
        public IError OnError(IError error)
        {
            if (error.Exception is null)
            {
                return error.WithException(new Exception());
            }
            else
            {
                return error;
            }
        }
    }
}
