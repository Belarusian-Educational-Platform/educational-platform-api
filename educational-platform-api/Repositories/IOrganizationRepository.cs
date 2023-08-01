using educational_platform_api.DTOs;
using educational_platform_api.Models;

namespace educational_platform_api.Repositories
{
    public interface IOrganizationRepository
    {
        public IEnumerable<Organization> GetAll();
        public Organization GetById(int id);
        public Organization GetByProfile(int profileId);

        public Organization Create(Organization organization);
        public void Update(Organization organization);
        public void Delete(Organization organization);
    }
}
