using educational_platform_api.Contexts;
using educational_platform_api.Exceptions.RepositoryExceptions;
using educational_platform_api.Models;

namespace educational_platform_api.Repositories
{
    public class GroupOrganizationRelationRepository : IGroupOrganizationRelationRepository
    {
        private readonly MySQLContext _dbContext;

        public GroupOrganizationRelationRepository(MySQLContext dbContext)
        {
            _dbContext = dbContext;
        }

        public GroupOrganizationRelation Create(GroupOrganizationRelation relation)
        {
            GroupOrganizationRelation relationEntity;
            try
            {
                relationEntity = _dbContext.GroupOrganizationRelations.Add(relation).Entity;
            }
            catch (Exception ex)
            {
                throw new EntityCreateException(nameof(GroupOrganizationRelation), ex.Message, ex);
            }

            return relationEntity;
        }

        public void Delete(params GroupOrganizationRelation[] relations)
        {
            try
            {
                _dbContext.GroupOrganizationRelations.RemoveRange(relations);
            } catch (Exception ex)
            {
                throw new EntityDeleteException(nameof(GroupOrganizationRelation), ex.Message, ex);
            }
        }

        public GroupOrganizationRelation GetByGroupId(int groupId)
        {
            GroupOrganizationRelation relation;
            try
            {
                relation = _dbContext.GroupOrganizationRelations.First(x => x.GroupId == groupId);
            } catch (Exception ex)
            {
                throw new EntityNotFoundException(nameof(GroupOrganizationRelation), ex.Message, ex);
            }

            return relation;
        }

        public IEnumerable<GroupOrganizationRelation> GetByOrganizationId(int organizationId)
        {
            var relations = _dbContext.GroupOrganizationRelations
                .Where(x => x.OrganizationId == organizationId)
                .ToList();

            return relations;
        }
    }
}
