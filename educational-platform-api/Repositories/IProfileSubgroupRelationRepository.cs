namespace educational_platform_api.Repositories
{
    public interface IProfileSubgroupRelationRepository
    {
        public string GetPermissions(int profileId, int subgroupId);
    }
}
