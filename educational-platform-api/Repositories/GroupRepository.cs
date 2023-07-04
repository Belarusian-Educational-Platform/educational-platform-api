using educational_platform_api.Contexts;
using educational_platform_api.Models;
using Microsoft.EntityFrameworkCore;

namespace educational_platform_api.Repositories
{
    public class GroupRepository : IGroupRepository, IAsyncDisposable
    {
        private readonly MySQLContext dbContext;

        public GroupRepository(IDbContextFactory<MySQLContext> dbContextFactory)
        {
            dbContext = dbContextFactory.CreateDbContext();
        }

        public ValueTask DisposeAsync()
        {
            return dbContext.DisposeAsync();
        }
    }
}
