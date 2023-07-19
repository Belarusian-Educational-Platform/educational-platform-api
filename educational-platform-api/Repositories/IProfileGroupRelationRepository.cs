using educational_platform_api.Models;

namespace educational_platform_api.Repositories
{
    public interface IProfileGroupRelationRepository
    {
        public ProfileGroupRelation GetRelation(int profileId, int groupId);
    }
}
