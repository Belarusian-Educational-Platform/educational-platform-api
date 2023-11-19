using HotChocolate.Types.Descriptors;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace api.Middlewares.UseAccount
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
            descriptor.Use<AccountMiddleware>();
        }
    }
}
