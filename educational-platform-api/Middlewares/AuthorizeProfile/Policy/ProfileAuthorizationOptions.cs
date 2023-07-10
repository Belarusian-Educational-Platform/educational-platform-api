namespace educational_platform_api.Middlewares.AuthorizeProfile.Policy
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
            return ProfilePolicyMap[policyName];
        }

        public ProfileAuthorizationPolicy GetDefaultPolicy()
        {
            return new ProfileAuthorizationPolicy();
        }
    }
}
