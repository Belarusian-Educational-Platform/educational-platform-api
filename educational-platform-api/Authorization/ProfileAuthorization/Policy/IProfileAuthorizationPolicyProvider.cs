namespace educational_platform_api.Authorization.ProfileAuthorization.Policy
{
    public interface IProfileAuthorizationPolicyProvider
    {
        public ProfileAuthorizationPolicy GetPolicy(string policyName);
    }
}
