using educational_platform_api.Models;

namespace educational_platform_api.Repositories
{
    public interface IProfileOrganizationRelationRepository
    {
        public ProfileOrganizationRelation GetByProfileId(int profileId);
        public bool TryGetByProfileId(int profileId, out ProfileOrganizationRelation relation);
        public bool TryGetByEntityIds(int profileId, int organizationId, out ProfileOrganizationRelation relation);
        public IEnumerable<ProfileOrganizationRelation> GetByOrgnizationId(int organizationId);

        public ProfileOrganizationRelation Create(ProfileOrganizationRelation relation);
        public void Delete(params ProfileOrganizationRelation[] relations);
    }
}
