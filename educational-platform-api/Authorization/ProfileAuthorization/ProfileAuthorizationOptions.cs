using educational_platform_api.Authorization.ProfileAuthorization.Policy;
using educational_platform_api.Exceptions.ProfileAuthorizationExceptions;

namespace educational_platform_api.Authorization.ProfileAuthorization
{
    public class ProfileAuthorizationOptions
    {
        public Dictionary<string, ProfileAuthorizationPolicy> ProfilePolicyMap { get; } =
            new Dictionary<string, ProfileAuthorizationPolicy>(StringComparer.OrdinalIgnoreCase);

        public void AddPolicy(string policyName, Action<ProfileAuthorizationPolicyBuilder> configure)
        {
            var policyBuilder = new ProfileAuthorizationPolicyBuilder();
            configure(policyBuilder);

            ProfilePolicyMap[policyName] = policyBuilder.Build();
        }

        public ProfileAuthorizationPolicy GetPolicy(string policyName)
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
