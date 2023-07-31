using educational_platform_api.Contexts;
using Microsoft.EntityFrameworkCore;

namespace educational_platform_api.Repositories
{
    public class SubgroupRepository : ISubgroupRepository
    {
        private readonly MySQLContext _dbContext;

        public SubgroupRepository(MySQLContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
