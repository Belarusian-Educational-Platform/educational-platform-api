namespace ProfileAuthorization
{
    public interface IAuthorizationService
    {
        public void Authorize(Action<VerificationOptions> configure, Predicate<IVerificationService> verify);
    }
}
