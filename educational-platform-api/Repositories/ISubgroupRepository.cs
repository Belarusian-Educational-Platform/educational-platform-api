using educational_platform_api.Models;

namespace educational_platform_api.Repositories
{
    public interface ISubgroupRepository
    {
        public IEnumerable<Subgroup> GetAll();
        public Subgroup GetById(int id);
        public IEnumerable<Subgroup> GetByGroupId(int groupId);
        public IEnumerable<Subgroup> GetByProfileId(int profileId);

        public Subgroup Create(Subgroup subgroup);
        public void Update(Subgroup subgroup);
        public void Delete(params Subgroup[] subgroups);
    }
}
