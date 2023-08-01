using educational_platform_api.DTOs.Relations;
using educational_platform_api.DTOs.Subgroup;
using educational_platform_api.Models;

namespace educational_platform_api.Services
{
    public interface ISubgroupService
    {
        public IEnumerable<Subgroup> GetAllSubgroups();
        public Subgroup GetSubgroupById(int id);
        public IEnumerable<Subgroup> GetProfileSubgroups(int profileId);
        public IEnumerable<Subgroup> GetGroupSubgroups(int groupId);

        public bool CheckCanAddProfileToSubgroup(int profileId, int subgroupId);
        public void CreateProfileSubgroupRelation(CreateProfileSubgroupRelationInput input);
        public void DeleteProfileSubgroupRelation(int profileId, int subgroupId);

        public Subgroup CreateSubgroup(CreateSubgroupInput input);
        public void UpdateSubgroup(UpdateSubgroupInput input);
        public void DeleteSubgroup(int id);
    }
}
