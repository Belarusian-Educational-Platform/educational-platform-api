namespace educational_platform_api.Middlewares.AuthorizeProfile
{
    public interface IProfileAuthorizationService
    {
        public void AuthorizeProfile(string policyName);
    }
}
