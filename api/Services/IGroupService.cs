using api.DTOs.Group;
using api.DTOs.Relations;
using api.Models;

namespace api.Services
{
    public interface IGroupService
    {
        public IQueryable<Group> GetAll();
        public IQueryable<Group> GetByOrganization(int organizationId);
        public Task<IQueryable<Group>> GetByProfileOrganization(int profileId);
        public IQueryable<Group> GetById(int id);

        public Task<int> Create(CreateGroupInput input);
        public Task Update(UpdateGroupInput input);
        public Task Delete(int id);

        public Task UpdateProfileGroupRelation(UpdateProfileGroupRelationInput input);
        public Task CreateProfileGroupRelation(CreateProfileGroupRelationInput input);
        public Task DeleteProfileGroupRelation(int profileId, int groupId);
    }
}
