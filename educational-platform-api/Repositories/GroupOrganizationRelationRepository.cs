using educational_platform_api.Contexts;
using educational_platform_api.Exceptions.RepositoryExceptions;
using educational_platform_api.Models;
using Microsoft.EntityFrameworkCore;

namespace educational_platform_api.Repositories
{
    public class GroupOrganizationRelationRepository : IGroupOrganizationRelationRepository, IAsyncDisposable
    {
        private readonly MySQLContext _dbContext;

        public GroupOrganizationRelationRepository(IDbContextFactory<MySQLContext> dbContextFactory)
        {
            _dbContext = dbContextFactory.CreateDbContext();
        }

        private void Save()
        {
            _dbContext.SaveChanges();
        }

        public ValueTask DisposeAsync()
        {
            return _dbContext.DisposeAsync();
        }

        public void CreateRelation(GroupOrganizationRelation relation)
        {
            try
            {
                _dbContext.GroupOrganizationRelations.Add(relation);
                Save();
            } catch (Exception ex)
            {
                throw new EntityCreateException(nameof(GroupOrganizationRelation), ex.Message, ex);
            }
        }
    }
}
