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

        public void AuthorizeProfile(string policyName)
        {
            ProfileAuthorizationPolicy policy = _policyProvider.GetPolicy(policyName);

            foreach (var requirement in policy._requierements)
            {
                if (!_policyVerifier.VerifyRequirement(requirement))
                {
                    throw new Exception("Requirement failed!");
                }
            }

            foreach (var assertion in policy._assertions)
            {
                if (!assertion(_policyVerifier.VerifyRequirement))
                {
                    throw new Exception("Assertion failed!");
                }
            }
        }
    }
}
