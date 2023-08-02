using educational_platform_api.Authorization.ProfileAuthorization.Policy;
using educational_platform_api.Exceptions.ProfileAuthorizationExceptions;

namespace educational_platform_api.Authorization.ProfileAuthorization
{
    public class ProfileAuthorizationService : IProfileAuthorizationService
    {
        private readonly IProfileAuthorizationPolicyProvider _policyProvider;
        private readonly IProfileAuthorizationPolicyVerifier _policyVerifier;

        public ProfileAuthorizationService(
            IProfileAuthorizationPolicyProvider policyProvider,
            IProfileAuthorizationPolicyVerifier policyVerifier)
        {
            _policyProvider = policyProvider;
            _policyVerifier = policyVerifier;
        }

        public void Authorize(Action<ProfileAuthorizationVerificationOptions> configure)
        {
            var verificationOptions = new ProfileAuthorizationVerificationOptions();
            configure(verificationOptions);

            ProfileAuthorizationPolicy policy = _policyProvider.GetPolicy(verificationOptions.PolicyName);
            bool verificationResult = _policyVerifier.Verify(policy, verificationOptions);

            if(!verificationResult)
            {
                throw new ProfileUnauthorizedException();
            }
        }
    }
}
