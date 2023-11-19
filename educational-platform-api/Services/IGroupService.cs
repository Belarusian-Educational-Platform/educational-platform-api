using educational_platform_api.DTOs.Group;
using educational_platform_api.DTOs.Relations;
using educational_platform_api.Models;

namespace educational_platform_api.Services
{
    public interface IGroupService
    {
        public IQueryable<Group> GetAll(int organizationId);
        public IQueryable<Group> GetAllByProfile(int profileId);
        public IQueryable<Group> GetById(int id);

        public int Create(CreateGroupInput input);
        public void Update(UpdateGroupInput input);
        public void Delete(int id);

        public void UpdateProfileGroupRelation(UpdateProfileGroupRelationInput input);

        public bool CheckOrganizationCorrespondence(int profileId, int groupId);
        public void CreateProfileGroupRelation(CreateProfileGroupRelationInput input);
        public void DeleteProfileGroupRelation(int profileId, int groupId);
    }
}
