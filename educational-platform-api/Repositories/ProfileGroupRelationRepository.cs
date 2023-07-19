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

        public ProfileGroupRelation GetRelation(int profileId, int groupId)
        {
            ProfileGroupRelation relation = dbContext.ProfileGroupRelations
                .First(predicate: relation => relation.ProfileId == profileId && relation.GroupId == groupId);
            return relation;
        }
    }
}
