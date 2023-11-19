using Microsoft.Extensions.Options;
using profile_authorization.Policy;

namespace ProfileAuthorization
{
    public class PolicyProvider : IPolicyProvider
    {
        private readonly AuthorizationOptions _options;

        public PolicyProvider(IOptions<AuthorizationOptions> options)
        {
            _options = options.Value;
        }

        public Policy GetPolicy(string policyName)
        {
            return _options.GetPolicy(policyName);
        }
    }
}
