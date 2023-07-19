using educational_platform_api.Authorization.ProfileAuthorization.Permission;

namespace educational_platform_api.Authorization.ProfileAuthorization.Policy
{
    public interface IProfileAuthorizationPolicyVerifier
    {
        public bool Verify(ProfileAuthorizationPolicy policy, ProfileAuthorizationVerificationOptions verificationOptions);

    }
}
