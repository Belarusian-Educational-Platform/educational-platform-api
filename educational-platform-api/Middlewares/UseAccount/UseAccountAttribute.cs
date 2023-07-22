using educational_platform_api.Models;
using FluentValidation;
using HotChocolate.Types;
using HotChocolate.Types.Descriptors;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace educational_platform_api.Middlewares.UseAccount
{
    public class UseAccountAttribute : ObjectFieldDescriptorAttribute
    {
        public UseAccountAttribute([CallerLineNumber] int order = 0)
        {
            Order = order;
        }

        protected override void OnConfigure(IDescriptorContext context,
            IObjectFieldDescriptor descriptor,
            MemberInfo member)
        {
            descriptor.Use((provider, next) => 
                new AccountMiddleware(next, provider.GetRequiredService<IValidator<Account>>()));
        }
    }
}
