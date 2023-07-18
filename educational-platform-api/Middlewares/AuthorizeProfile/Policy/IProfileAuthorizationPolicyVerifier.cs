namespace educational_platform_api.Middlewares.AuthorizeProfile.Policy
{
    public interface IProfileAuthorizationPolicyVerifier
    {
       public bool VerifyRequirement(ProfileAuthorizationPermission requirement);
        public List<ProfileAuthorizationPermission> GetProfilePermissions(ProfileAuthorizationCheckOptions checkOptions);
        public bool Verify(ProfileAuthorizationPolicy policy, ProfileAuthorizationCheckOptions checkOptions);

    }
}
