namespace ProfileAuthorization
{
    public interface IPermissionService
    {
        Task<PermissionSet> GetProfilePermissions(VerificationOptions verificationOptions);
    }
}
