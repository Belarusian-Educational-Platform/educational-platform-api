using educational_platform_api.Contexts;
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

        public string GetPermissions(int profileId, int organizationId)
        {
            throw new NotImplementedException();
        }
    }
}
