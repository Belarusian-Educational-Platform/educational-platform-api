using educational_platform_api.Contexts;
using educational_platform_api.Exceptions.RepositoryExceptions;
using educational_platform_api.Models;
using Microsoft.EntityFrameworkCore;

namespace educational_platform_api.Repositories
{
    public class ProfileGroupRelationRepository : IProfileGroupRelationRepository, IAsyncDisposable
    {
        private readonly MySQLContext _dbContext;

        public ProfileGroupRelationRepository(IDbContextFactory<MySQLContext> dbContextFactory)
        {
            _dbContext = dbContextFactory.CreateDbContext();
        }

        public ValueTask DisposeAsync()
        {
            return _dbContext.DisposeAsync();
        }

        public ProfileGroupRelation GetRelation(int profileId, int groupId)
        {
            ProfileGroupRelation relation;
            
            try
            {
                relation = _dbContext.ProfileGroupRelations
                    .First(relation => relation.ProfileId == profileId && relation.GroupId == groupId);
            } catch (Exception ex)
            {
                throw new EntityNotFoundException(nameof(ProfileGroupRelation), ex.Message, ex);
            }

            return relation;
        }
    }
}
