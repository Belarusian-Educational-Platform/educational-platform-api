using Microsoft.Extensions.Options;

namespace educational_platform_api.Middlewares.AuthorizeProfile.Policy
{
    public class ProfileAuthorizationPolicyProvider : IProfileAuthorizationPolicyProvider
    {
        private readonly ProfileAuthorizationOptions _options;

        public ProfileAuthorizationPolicyProvider(IOptions<ProfileAuthorizationOptions> options)
        {
            _options = options.Value;
        }

        public ProfileAuthorizationPolicy GetPolicy(string policyName)
        {
            return _options.GetPolicy(policyName);
        }
    }
}
