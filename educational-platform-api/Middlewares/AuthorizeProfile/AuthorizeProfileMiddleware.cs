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
            IProfileAuthorizationPolicyProvider policyProvider, 
            IProfileAuthorizationPolicyVerifier policyVerifier)
        {
            ProfileAuthorizationPolicy policy = policyProvider.GetPolicy(_policyName);

            foreach (var requirement in policy._requierements)
            {
                if(!policyVerifier.VerifyRequirement(requirement))
                {
                    throw new Exception("Requirement failed!");
                }
            }

            foreach (var assertion in policy._assertions)
            {
                if(!assertion(policyVerifier.VerifyRequirement))
                {
                    throw new Exception("Assertion failed!");
                }
            }

            await _next(context);
        }
    }
}
