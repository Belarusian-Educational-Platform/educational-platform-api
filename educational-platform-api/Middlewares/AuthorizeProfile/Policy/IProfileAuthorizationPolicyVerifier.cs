namespace educational_platform_api.Middlewares.AuthorizeProfile.Policy
{
    public interface IProfileAuthorizationPolicyVerifier
    {
        public bool VerifyRequirement(ProfileAuthorizationRequirement requirement);
        public void GetProfilePermissions();
    }
}
