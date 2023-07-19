using educational_platform_api.Models;

namespace educational_platform_api.Repositories
{
    public interface IProfileOrganizationRelationRepository
    {
        public ProfileOrganizationRelation GetRelation(int profileId);
    }
}
