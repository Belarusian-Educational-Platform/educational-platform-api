using educational_platform_api.Contexts;
using educational_platform_api.Exceptions.RepositoryExceptions;
using educational_platform_api.Models;
using Microsoft.EntityFrameworkCore;

namespace educational_platform_api.Repositories
{
    public class GroupOrganizationRelationRepository : IGroupOrganizationRelationRepository
    {
        private readonly MySQLContext _dbContext;

        public GroupOrganizationRelationRepository(MySQLContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void CreateRelation(GroupOrganizationRelation relation)
        {
            try
            {
                _dbContext.GroupOrganizationRelations.Add(relation);
            } catch (Exception ex)
            {
                throw new EntityCreateException(nameof(GroupOrganizationRelation), ex.Message, ex);
            }
        }
    }
}
