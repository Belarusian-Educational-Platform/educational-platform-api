namespace educational_platform_api.Authorization.ProfileAuthorization.Permission
{
    public interface IProfileAuthorizationPermissionService
    {
        ProfileAuthorizationPermissionSet GetProfilePermissions(ProfileAuthorizationVerificationOptions verificationOptions);
    }
}