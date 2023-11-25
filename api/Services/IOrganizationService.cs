using api.DTOs.Organization;
using api.DTOs.Relations;
using api.Models;

namespace api.Services
{
    public interface IOrganizationService
    {
        public IQueryable<Organization> GetAll();
        public IQueryable<Organization> GetById(int id);

        public Task<int> Create(CreateOrganizationInput input);
        public Task Update(UpdateOrganizationInput input);
        public Task Delete(int id);

        public Task UpdateProfileOrganizationRelation(UpdateProfileOrganizationRelationInput input);
        public Task<bool> CheckProfileInOrganization(int profileId, int organizationId);
    }
}
