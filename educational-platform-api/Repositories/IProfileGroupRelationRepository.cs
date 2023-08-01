using educational_platform_api.Models;

namespace educational_platform_api.Repositories
{
    public interface IProfileGroupRelationRepository
    {
        public ProfileGroupRelation GetByEntityIds(int profileId, int groupId);
        public bool TryGetByEntityIds(int profileId, int groupId, out ProfileGroupRelation relation);
        public IEnumerable<ProfileGroupRelation> GetByProfileId(int profileId);
        public IEnumerable<ProfileGroupRelation> GetByGroupId(int groupId);

        public ProfileGroupRelation Create(ProfileGroupRelation relation);
        public void Delete(params ProfileGroupRelation[] relations);
    }
}
