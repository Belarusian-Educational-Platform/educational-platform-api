using educational_platform_api.DTOs;
using educational_platform_api.Models;

namespace educational_platform_api.Repositories
{
    public interface IOrganizationRepository
    {
        public IEnumerable<Organization> GetOrganizations();
        public Organization GetOrganization(int id);
        public Organization GetProfileOrganization(int profileId);

        public Organization CreateOrganization(Organization organization);
        public void UpdateOrganization(Organization organization);
        public void DeleteOrganization(Organization organization);
    }
}
