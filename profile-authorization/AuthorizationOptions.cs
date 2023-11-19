using ProfileAuthorization.Exceptions;

namespace ProfileAuthorization
{
    public class AuthorizationOptions
    {
        public Dictionary<string, Policy> ProfilePolicyMap { get; } =
            new Dictionary<string, Policy>(StringComparer.OrdinalIgnoreCase);

        public void AddPolicy(string policyName, Action<PolicyBuilder> configure)
        {
            var policyBuilder = new PolicyBuilder();
            configure(policyBuilder);

            ProfilePolicyMap[policyName] = policyBuilder.Build();
        }

        public Policy GetPolicy(string policyName)
        {
            if (!ProfilePolicyMap.ContainsKey(policyName))
            {
                throw new RequestedPolicyNotExistsException(); 
            }
            else
            {
                return ProfilePolicyMap[policyName];
            }
        }
    }
}
