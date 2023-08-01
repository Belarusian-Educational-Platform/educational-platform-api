using educational_platform_api.Models;

namespace educational_platform_api.Repositories
{
    public interface IGroupRepository
    {
        public IEnumerable<Group> GetAll();
        public Group GetById(int id);
        public IEnumerable<Group> GetByProfileId(int profileId);
        public IEnumerable<Group> GetByOrgnizationId(int organizationId);

        public Group Create(Group group);
        public void Update(Group group);
        public void Delete(Group group);
    }
}
