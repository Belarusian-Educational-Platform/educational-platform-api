using HotChocolate.Types.Descriptors;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace educational_platform_api.Middlewares.UseProfile
{
    public class UseProfileAttribute : ObjectFieldDescriptorAttribute
    {
        public UseProfileAttribute([CallerLineNumber] int order = 0)
        {
            Order = order;
        }

        protected override void OnConfigure(IDescriptorContext context,
            IObjectFieldDescriptor descriptor,
            MemberInfo member)
        {
            descriptor.Use<ProfileMiddleware>();
        }
    }
}
