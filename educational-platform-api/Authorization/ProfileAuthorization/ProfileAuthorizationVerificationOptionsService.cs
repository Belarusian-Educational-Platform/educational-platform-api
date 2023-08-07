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

        public bool CheckOrganizationСorrespondence(ProfileAuthorizationVerificationOptions options)
        {
            var profile = _dbContext.Profiles
                .Include(p => p.OrganizationRelation)
                .FirstOrDefault(p => p.Id == options.ProfileId);
            if (profile is null) {
                throw new EntityNotFoundException(nameof(Profile));
            }
            var organizationId = profile.OrganizationRelation.OrganizationId;
            
            if (options.VerificationLevels.Contains(ProfileAuthorizationPermissionLevel.PROFILE_GROUP))
            {
                var group = _dbContext.Groups
                    .Include(g => g.OrganizationRelation)
                    .FirstOrDefault(g => g.Id == options.GroupId);
                if (group is null) {
                    throw new EntityNotFoundException(nameof(Group));
                }
                if (!group.OrganizationRelation.OrganizationId.Equals(organizationId))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
