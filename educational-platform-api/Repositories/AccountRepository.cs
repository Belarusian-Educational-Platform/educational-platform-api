using educational_platform_api.Contexts;
using Microsoft.EntityFrameworkCore;

namespace educational_platform_api.Repositories
{
    public class AccountRepository : IAccountRepository, IAsyncDisposable
    {
        private readonly MySQLContext _dbContext;

        public AccountRepository(IDbContextFactory<MySQLContext> dbContextFactory)
        {
            _dbContext = dbContextFactory.CreateDbContext();
        }

        public ValueTask DisposeAsync()
        {
            return _dbContext.DisposeAsync();
        }
    }
}
