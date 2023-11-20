namespace ProfileAuthorization
{
    public interface IPermissionService
    {
        PermissionSet GetProfilePermissions(VerificationOptions verificationOptions, Policy policy);
    }
}
