using educational_platform_api.Contexts;
using educational_platform_api.Exceptions.RepositoryExceptions;
using educational_platform_api.Models;
using educational_platform_api.Types.Enums;
using Microsoft.EntityFrameworkCore;

namespace educational_platform_api.Authorization.ProfileAuthorization
{
    public class ProfileAuthorizationVerificationOptionsService : IProfileAuthorizationVerificationOptionsService, 
        IAsyncDisposable
    {
        private readonly MySQLContext _dbContext;

        public ProfileAuthorizationVerificationOptionsService(IDbContextFactory<MySQLContext> dbContextFactory)
        {
            _dbContext = dbContextFactory.CreateDbContext();
        }

        public ValueTask DisposeAsync()
        {
            return _dbContext.DisposeAsync();
        }

        // TODO: RENAME?
        public bool CheckOrganizationСorrespondence(ProfileAuthorizationVerificationOptions options)
        {
            var profile = _dbContext.Profiles
                .Include(p => p.OrganizationRelation)
                .Include(p => p.GroupRelations)
                .FirstOrDefault(p => p.Id == options.ProfileId);

            if (profile is null) {
                throw new EntityNotFoundException(nameof(Profile));
            }
            
            if (options.VerificationLevels.Contains(ProfileAuthorizationPermissionLevel.PROFILE_GROUP))
            {
                if (!profile.GroupRelations.Any(pgr => pgr.GroupId == options.GroupId))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
