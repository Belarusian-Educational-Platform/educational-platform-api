using api.DTOs.Organization;
using api.DTOs.Relations;
using api.Models;

namespace api.Services
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
