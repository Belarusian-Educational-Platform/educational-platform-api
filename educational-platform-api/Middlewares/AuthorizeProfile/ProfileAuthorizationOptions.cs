namespace educational_platform_api.Middlewares.AuthorizeProfile
{
    public class ProfileAuthorizationOptions
    {
        public Dictionary<string, ProfilePolicy> ProfilePolicyMap { get; } = 
            new Dictionary<string, ProfilePolicy>(StringComparer.OrdinalIgnoreCase);

        public void AddPolicy(string policyName, ProfilePolicy policy)
        {
            ProfilePolicyMap[policyName] = policy;
        }
    }
}
