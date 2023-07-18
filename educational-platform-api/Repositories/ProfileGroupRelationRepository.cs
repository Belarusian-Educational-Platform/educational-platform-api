using educational_platform_api.Contexts;
using educational_platform_api.Models;
using Microsoft.EntityFrameworkCore;

namespace educational_platform_api.Repositories
{
    public class ProfileGroupRelationRepository : IProfileGroupRelationRepository, IAsyncDisposable
    {
        private readonly MySQLContext dbContext;

        public ProfileGroupRelationRepository(IDbContextFactory<MySQLContext> dbContextFactory)
        {
            dbContext = dbContextFactory.CreateDbContext();
        }

        public ValueTask DisposeAsync()
        {
            return dbContext.DisposeAsync();
        }

        public string GetPermissions(int profileId, int groupId)
        {
            ProfileSubgroupRelation relation = dbContext.ProfileSubgroupRelations
                .First(predicate: relation => relation.ProfileId == profileId && relation.SubgroupId == groupId);

            string permissions = relation.Permissions;

            return permissions;
        }
    }
}
