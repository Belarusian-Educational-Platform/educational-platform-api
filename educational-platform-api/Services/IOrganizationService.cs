using educational_platform_api.DTOs.Organization;
using educational_platform_api.Models;

namespace educational_platform_api.Services
{
    public interface IOrganizationService
    {
        public IQueryable<Organization> GetAll();
        public IQueryable<Organization> GetById(int id);

        public Organization CreateOrganization(CreateOrganizationInput input);
        public void UpdateOrganization(UpdateOrganizationInput input);
        public void DeleteOrganization(int id);

        public bool CheckProfileInOrganization(int profileId, int organizationId);
    }
}
