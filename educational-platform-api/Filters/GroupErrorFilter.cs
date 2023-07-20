﻿using educational_platform_api.Exceptions;
using HotChocolate;

namespace educational_platform_api.Filters
{
    public class GroupErrorFilter : IErrorFilter
    {
        public IError OnError(IError error)
        {
            if (typeof(BaseGroupException).IsAssignableFrom(error.Exception.GetType()))
            {
                return error.WithMessage("Exception inherits BaseGroupException");
            }
            else
            {
                return error;
            }
        }
    }
}
