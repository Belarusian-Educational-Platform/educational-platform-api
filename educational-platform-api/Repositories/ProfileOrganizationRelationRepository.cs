using educational_platform_api.Contexts;
using educational_platform_api.Models;
using Microsoft.EntityFrameworkCore;

namespace educational_platform_api.Repositories
{
    public class ProfileOrganizationRelationRepository : IProfileOrganizationRelationRepository, IAsyncDisposable
    {
        private readonly MySQLContext dbContext;

        public ProfileOrganizationRelationRepository(IDbContextFactory<MySQLContext> dbContextFactory)
        {
            dbContext = dbContextFactory.CreateDbContext();
        }

        public ValueTask DisposeAsync()
        {
            return dbContext.DisposeAsync();
        }

        public string GetPermissions(int profileId)
        {
            ProfileSubgroupRelation relation = dbContext.ProfileSubgroupRelations
                .First(predicate: relation => relation.ProfileId == profileId);

            string permissions = relation.Permissions;

            return permissions;
        }
    }
}
