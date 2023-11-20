using ProfileAuthorization.Exceptions;

namespace ProfileAuthorization
{
    public class AuthorizationService : IAuthorizationService
    {
        private readonly IPolicyProvider _policyProvider;
        private readonly IPolicyVerifier _policyVerifier;

        public AuthorizationService(
            IPolicyProvider policyProvider,
            IPolicyVerifier policyVerifier)
        {
            _policyProvider = policyProvider;
            _policyVerifier = policyVerifier;
        }

        public void Authorize(Action<VerificationOptions> configure)
        {
            var verificationOptions = new VerificationOptions();
            configure(verificationOptions);

            var policy = _policyProvider.GetPolicy(verificationOptions.PolicyName);
            bool verificationResult = _policyVerifier.Verify(policy, verificationOptions);

            if(!verificationResult)
            {
                throw new ProfileUnauthorizedException();
            }
        }
    }
}
