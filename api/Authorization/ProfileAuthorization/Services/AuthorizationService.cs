using ProfileAuthorization.Exceptions;

namespace ProfileAuthorization
{
    public class AuthorizationService : IAuthorizationService
    {
        private readonly IVerificationService _verificationService;

        public AuthorizationService(IVerificationService verificationService)
        {
            _verificationService = verificationService;
        }

        public async Task Authorize(Action<VerificationOptions> configure, 
            Predicate<IVerificationService> verify)
        {
            var verificationOptions = new VerificationOptions();
            configure(verificationOptions);

            await _verificationService.UseOptions(verificationOptions);

            if(!verify(_verificationService))
            {
                throw new ProfileUnauthorizedException();
            }
        }
    }
}
