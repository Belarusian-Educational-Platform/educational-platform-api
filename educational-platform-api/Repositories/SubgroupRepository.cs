using educational_platform_api.Contexts;
using Microsoft.EntityFrameworkCore;

namespace educational_platform_api.Repositories
{
    public class SubgroupRepository : ISubgroupRepository, IAsyncDisposable
    {
        private readonly MySQLContext dbContext;

        public SubgroupRepository(IDbContextFactory<MySQLContext> dbContextFactory)
        {
            dbContext = dbContextFactory.CreateDbContext();
        }

        public ValueTask DisposeAsync()
        {
            return dbContext.DisposeAsync();
        }
    }
}
