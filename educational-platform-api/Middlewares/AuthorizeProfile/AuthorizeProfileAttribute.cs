﻿using HotChocolate.Types.Descriptors;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace educational_platform_api.Middlewares.AuthorizeProfile
{
    public class AuthorizeProfileAttribute : ObjectFieldDescriptorAttribute
    {

        private readonly string PolicyName;

        public AuthorizeProfileAttribute(string policyName = "default-policy", [CallerLineNumber] int order = 0)
        {
            Order = order;
            PolicyName = policyName;
        }

        protected override void OnConfigure(IDescriptorContext context, 
            IObjectFieldDescriptor descriptor, 
            MemberInfo member)
        {
            descriptor
                .Use((provider, next) => new AuthorizeProfileMiddleware(next, PolicyName));
        }
    }
}
