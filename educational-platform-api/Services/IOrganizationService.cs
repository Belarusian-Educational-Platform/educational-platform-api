using educational_platform_api.DTOs.Organization;
using educational_platform_api.DTOs.Relations;
using educational_platform_api.Models;

namespace educational_platform_api.Services
{
    public interface IOrganizationService
    {
        public IQueryable<Organization> GetAll();
        public IQueryable<Organization> GetById(int id);

        public int Create(CreateOrganizationInput input);
        public void Update(UpdateOrganizationInput input);
        public void Delete(int id);

        public void UpdateProfileOrganizationRelation(UpdateProfileOrganizationRelationInput input);
        public bool CheckProfileInOrganization(int profileId, int organizationId);
    }
}
