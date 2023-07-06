using HotChocolate.Types.Descriptors;
using System.Reflection;

namespace educational_platform_api.Middlewares.AuthorizeProfile
{
    public class AuthorizeProfileAttribute : ObjectFieldDescriptorAttribute
    {
        protected override void OnConfigure(IDescriptorContext context, 
            IObjectFieldDescriptor descriptor, 
            MemberInfo member)
        {
            descriptor.Use((provider, next) => new AuthorizeProfileMiddleware(next));
        }
    }
}
