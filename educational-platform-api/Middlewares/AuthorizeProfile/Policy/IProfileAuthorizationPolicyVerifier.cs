namespace educational_platform_api.Middlewares.AuthorizeProfile.Policy
{
    public interface IProfileAuthorizationPolicyVerifier
    {
       public bool VerifyRequirement(ProfileAuthorizationPermission requirement);
        public List<ProfileAuthorizationPermission> GetProfilePermissions(ProfileAuthorizationVerificationOptions checkOptions);
        public bool Verify(ProfileAuthorizationPolicy policy, ProfileAuthorizationVerificationOptions checkOptions);

    }
}
