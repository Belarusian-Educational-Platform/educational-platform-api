using educational_platform_api.Models;

namespace educational_platform_api.Repositories
{
    public interface IProfileSubgroupRelationRepository
    {
        public ProfileSubgroupRelation GetRelation(int profileId, int subgroupId);
    }
}
