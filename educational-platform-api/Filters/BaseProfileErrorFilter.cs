﻿using educational_platform_api.Exceptions;
using HotChocolate;

namespace educational_platform_api.Filters
{
    public class BaseProfileErrorFilter : IErrorFilter
    {
        public IError OnError(IError error)
        {
            if ( typeof(BaseProfileException).IsAssignableFrom(error.Exception.GetType()))
            {
                return error.WithMessage("Exception inhearts BaseUserException");
            }
            else
            {
                return error;
            }
        }
    }
}