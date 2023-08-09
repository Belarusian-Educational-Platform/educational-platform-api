using educational_platform_api.Contexts;
using educational_platform_api.Exceptions.RepositoryExceptions;
using educational_platform_api.Models;
using educational_platform_api.Types.Enums;
using Microsoft.EntityFrameworkCore;

namespace educational_platform_api.Authorization.ProfileAuthorization.Permission
{
    public class ProfileAuthorizationPermissionService : IProfileAuthorizationPermissionService, IAsyncDisposable
    {
        private readonly MySQLContext _dbContext;

        public ProfileAuthorizationPermissionService(IDbContextFactory<MySQLContext> dbContextFactory)
        {
            _dbContext = dbContextFactory.CreateDbContext();
        }

        public ValueTask DisposeAsync()
        {
            return _dbContext.DisposeAsync();
        }

        public ProfileAuthorizationPermissionSet GetProfilePermissions(
            ProfileAuthorizationVerificationOptions verificationOptions)
        {
            ProfileAuthorizationPermissionSet permissionSet = new();
            string rawPermissions;

            var profile = _dbContext.Profiles
                    .Include(p => p.OrganizationRelation)
                    .Include(p => p.GroupRelations)
                    .FirstOrDefault(p => p.Id == verificationOptions.ProfileId);
            if (profile is null)
            {
                throw new EntityNotFoundException(nameof(Profile));
            }

            if (verificationOptions.VerificationLevels.Contains(ProfileAuthorizationPermissionLevel.PROFILE_ORGANIZATION))
            {
                rawPermissions = profile.OrganizationRelation.Permissions;

                permissionSet.AddPermissions(ProfileAuthorizationPermissionLevel.PROFILE_ORGANIZATION, rawPermissions);
            }
            if (verificationOptions.VerificationLevels.Contains(ProfileAuthorizationPermissionLevel.PROFILE_GROUP))
            {
                var groupRelation = profile.GroupRelations
                    .FirstOrDefault(pgr => pgr.GroupId == verificationOptions.GroupId);
                if(groupRelation is null)
                {
                    throw new EntityNotFoundException(nameof(ProfileGroupRelation));
                }
                rawPermissions = groupRelation.Permissions;
                
                permissionSet.AddPermissions(ProfileAuthorizationPermissionLevel.PROFILE_GROUP, rawPermissions);
            }

            return permissionSet;
        }
    }
}
