namespace educational_platform_api.Authorization.ProfileAuthorization
{
    public interface IProfileAuthorizationVerificationOptionsService
    {
        public bool CheckOrganizationСorrespondence(ProfileAuthorizationVerificationOptions options);
    }
}