using HotChocolate;

namespace educational_platform_api.Filters
{
    public class ErrorWithNullExceptionFilter : IErrorFilter
    {
        public IError OnError(IError error)
        {
            if (error.Exception is null)
            {
                //Add exception to error? Throw new error with null exception?Process all errors with null exceptions there?
                return error;
            }
            else
            {
                return error;
            }
        }
    }
}

/*
 How to better separate different exteptions types onto folders with their base exceptions
 */
