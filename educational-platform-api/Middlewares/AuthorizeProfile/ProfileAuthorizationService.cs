using educational_platform_api.Middlewares.AuthorizeProfile.Policy;

namespace educational_platform_api.Middlewares.AuthorizeProfile
{
    public class ProfileAuthorizationService : IProfileAuthorizationService
    {
        private readonly IProfileAuthorizationPolicyProvider _policyProvider;
        private readonly IProfileAuthorizationPolicyVerifier _policyVerifier;

        public ProfileAuthorizationService(IProfileAuthorizationPolicyProvider policyProvider, 
            IProfileAuthorizationPolicyVerifier policyVerifier)
        {
            _policyProvider = policyProvider;
            _policyVerifier = policyVerifier;
        }

        public void AuthorizeProfile(Action<ProfileAuthorizationCheckOptions> configure)
        {
            var options = new ProfileAuthorizationCheckOptions();
            configure(options);

            ProfileAuthorizationPolicy policy = _policyProvider.GetPolicy(options.PolicyName);
            _policyVerifier.Verify(policy, options);
        }

    }
}
