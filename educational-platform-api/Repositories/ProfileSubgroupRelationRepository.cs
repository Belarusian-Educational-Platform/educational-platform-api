using educational_platform_api.Contexts;
using educational_platform_api.Models;
using Microsoft.EntityFrameworkCore;

namespace educational_platform_api.Repositories
{
    public class ProfileSubgroupRelationRepository : IProfileSubgroupRelationRepository, IAsyncDisposable
    {
        private readonly MySQLContext _dbContext;

        public ProfileSubgroupRelationRepository(IDbContextFactory<MySQLContext> dbContextFactory)
        {
            _dbContext = dbContextFactory.CreateDbContext();
        }

        public ValueTask DisposeAsync()
        {
            return _dbContext.DisposeAsync();
        }

        public ProfileSubgroupRelation GetRelation(int profileId, int subgroupId)
        {
            ProfileSubgroupRelation relation = _dbContext.ProfileSubgroupRelations
                .First(relation => relation.ProfileId == profileId && relation.SubgroupId == subgroupId);

            return relation;
        }
    }
}
