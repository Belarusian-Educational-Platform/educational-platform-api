using educational_platform_api.Contexts;
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

        public ValueTask DisposeAsync()
        {
            return _dbContext.DisposeAsync();
        }
    }
}
