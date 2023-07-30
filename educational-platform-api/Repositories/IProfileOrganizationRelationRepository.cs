using educational_platform_api.Models;

namespace educational_platform_api.Repositories
{
    public interface IProfileOrganizationRelationRepository
    {
        public ProfileOrganizationRelation GetProfileRelation(int id);
        public IEnumerable<ProfileOrganizationRelation> GetOrganizationRelations(int id);
        public bool CheckRelationExists(int profileId, int organizationId);
    }
}
