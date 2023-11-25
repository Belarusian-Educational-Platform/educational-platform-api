namespace ProfileAuthorization
{
    public interface IAuthorizationService
    {
        public Task Authorize(Action<VerificationOptions> configure, Predicate<IVerificationService> verify);
    }
}
