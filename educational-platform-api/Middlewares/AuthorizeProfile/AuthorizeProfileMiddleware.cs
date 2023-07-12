using educational_platform_api.Middlewares.AuthorizeProfile.Policy;
using HotChocolate.Resolvers;

namespace educational_platform_api.Middlewares.AuthorizeProfile
{
    public class AuthorizeProfileMiddleware
    {
        private readonly FieldDelegate _next;
        private readonly string _policyName;

        public AuthorizeProfileMiddleware(FieldDelegate next, string policyName)
        {
            _next = next;
            _policyName = policyName;
        }

        public async Task InvokeAsync(IMiddlewareContext context, 
            IProfileAuthorizationService profileAuthorizationService)
        {
            profileAuthorizationService.AuthorizeProfile(_policyName);

            await _next(context);
        }
    }
}
