using Microsoft.AspNetCore.Authorization;

namespace educational_platform_api.Middlewares.AuthorizeProfile.Policy
{
    public interface IProfileAuthorizationPolicyProvider
    {
        public ProfileAuthorizationPolicy GetPolicy(string policyName);
        public ProfileAuthorizationPolicy GetDefaultPolicy();
    }
}
