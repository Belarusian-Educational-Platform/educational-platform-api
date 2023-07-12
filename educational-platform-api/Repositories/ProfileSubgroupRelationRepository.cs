using educational_platform_api.Contexts;
using educational_platform_api.Models;
using Microsoft.EntityFrameworkCore;

namespace educational_platform_api.Repositories
{
    public class ProfileSubgroupRelationRepository : IProfileSubgroupRelationRepository, IAsyncDisposable
    {
        private readonly MySQLContext dbContext;

        public ProfileSubgroupRelationRepository(IDbContextFactory<MySQLContext> dbContextFactory)
        {
            dbContext = dbContextFactory.CreateDbContext();
        }

        public ValueTask DisposeAsync()
        {
            return dbContext.DisposeAsync();
        }

        public string GetPermissions(int profileId, int subgroupId)
        {
            ProfileSubgroupRelation relation = dbContext.ProfileSubgroupRelations
                .FirstOrDefault(relation => relation.ProfileId == profileId && relation.SubgroupId == subgroupId);

            string permissions = relation.Permissions;

            return permissions;
        }
    }
}
