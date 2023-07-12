namespace educational_platform_api.Repositories
{
    public interface IProfileOrganizationRelationRepository
    {
        public string GetPermissions(int profileId, int organizationId);
    }
}
