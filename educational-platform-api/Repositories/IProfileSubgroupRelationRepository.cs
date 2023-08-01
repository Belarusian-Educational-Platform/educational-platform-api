using educational_platform_api.Models;

namespace educational_platform_api.Repositories
{
    public interface IProfileSubgroupRelationRepository
    {
        public ProfileSubgroupRelation GetByEntityIds(int profileId, int subgroupId);
        public bool TryGetByEntityIds(int profileId, int subgroupId, out ProfileSubgroupRelation relation);
        public IEnumerable<ProfileSubgroupRelation> GetByProfileId(int profileId);
        public IEnumerable<ProfileSubgroupRelation> GetBySubgroupId(int subgroupId);
        public IEnumerable<ProfileSubgroupRelation> GetByGroupId(int groupId);

        public ProfileSubgroupRelation Create(ProfileSubgroupRelation relation);
        public void Delete(params ProfileSubgroupRelation[] relations);
    }
}
