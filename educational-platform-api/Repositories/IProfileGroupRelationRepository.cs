namespace educational_platform_api.Repositories
{
    public interface IProfileGroupRelationRepository
    {
        public string GetPermissions(int profileId, int groupId);
    }
}
