﻿using System.Runtime.Serialization;

namespace ProfileAuthorization.Exceptions
{
    public class RequestedPolicyNotExistsException : BaseProfileAuthorizationException
    {
        public RequestedPolicyNotExistsException()
        {
        }

        public RequestedPolicyNotExistsException(string? message) : base(message)
        {
        }

        public RequestedPolicyNotExistsException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected RequestedPolicyNotExistsException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
