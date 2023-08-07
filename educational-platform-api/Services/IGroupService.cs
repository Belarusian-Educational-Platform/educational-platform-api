using educational_platform_api.DTOs.Group;
using educational_platform_api.DTOs.Relations;
using educational_platform_api.Models;

namespace educational_platform_api.Services
{
    public interface IGroupService
    {
        public IQueryable<Group> GetAll();
        public IQueryable<Group> GetById(int id);

        public bool CheckCanAddProfileToGroup(int profileId, int groupId);
        public void CreateProfileGroupRelation(CreateProfileGroupRelationInput input);
        public void DeleteProfileGroupRelation(int profileId, int groupId);

        public Group CreateGroup(CreateGroupInput input);
        public void UpdateGroup(UpdateGroupInput input);
        public void DeleteGroup(int id);
    }
}
