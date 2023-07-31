using educational_platform_api.Models;

namespace educational_platform_api.Repositories
{
    public interface IGroupRepository
    {
        public IEnumerable<Group> GetGroups();
        public Group GetGroupById(int id);
        public IEnumerable<Group> GetProfileGroups(int profileId);
        public IEnumerable<Group> GetOrganizationGroups(int organizationId);

        public Group CreateGroup(Group group);
        public void UpdateGroup(Group group);
        public void DeleteGroup(Group group);
    }
}
