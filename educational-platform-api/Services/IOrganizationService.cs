using educational_platform_api.DTOs;
using educational_platform_api.Models;

namespace educational_platform_api.Services
{
    public interface IOrganizationService
    {
        public IEnumerable<Organization> GetOrganizations();
        public Organization GetOrganization(int id);
        public Organization GetProfileOrganization(int profileId);

        public Organization CreateOrganization(CreateOrganizationInput input);
        public void UpdateOrganization(UpdateOrganizationInput input);
        public void DeleteOrganization(int id);

        public bool CheckProfileInOrganization(int profileId, int organizationId);
    }
}
