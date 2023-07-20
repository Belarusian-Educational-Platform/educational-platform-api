using educational_platform_api.Contexts;
using educational_platform_api.Models;
using Microsoft.EntityFrameworkCore;

namespace educational_platform_api.Repositories
{
    public class ProfileOrganizationRelationRepository : IProfileOrganizationRelationRepository, IAsyncDisposable
    {
        private readonly MySQLContext _dbContext;

        public ProfileOrganizationRelationRepository(IDbContextFactory<MySQLContext> dbContextFactory)
        {
            _dbContext = dbContextFactory.CreateDbContext();
        }

        public ValueTask DisposeAsync()
        {
            return _dbContext.DisposeAsync();
        }

        public ProfileOrganizationRelation GetRelation(int profileId)
        {
            ProfileOrganizationRelation relation = _dbContext.ProfileOrganizationRelations
                .First(relation => relation.ProfileId == profileId);

            return relation;
        }
    }
}
