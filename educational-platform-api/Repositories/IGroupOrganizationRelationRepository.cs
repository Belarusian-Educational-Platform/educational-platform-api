using educational_platform_api.Models;

namespace educational_platform_api.Repositories
{
    public interface IGroupOrganizationRelationRepository
    {
        public GroupOrganizationRelation GetByGroupId(int groupId);
        public IEnumerable<GroupOrganizationRelation> GetByOrgnizationId(int organizationId);

        public GroupOrganizationRelation Create(GroupOrganizationRelation relation);
        public void Delete(GroupOrganizationRelation relation);
    }
}
