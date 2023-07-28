namespace educational_platform_api.Authorization.ProfileAuthorization
{
    public interface IProfileAuthorizationService
    {
        public void Authorize(Action<ProfileAuthorizationVerificationOptions> configure);
    }
}
