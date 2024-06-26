﻿using System.Runtime.Serialization;

namespace educational_platform_api.Exceptions.ProfileAuthorizationExceptions
{
    public class ProfileUnauthorizedException : BaseProfileAuthorizationException
    {
        public ProfileUnauthorizedException()
        {
        }

        public ProfileUnauthorizedException(string? message) : base(message)
        {
        }

        public ProfileUnauthorizedException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected ProfileUnauthorizedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
