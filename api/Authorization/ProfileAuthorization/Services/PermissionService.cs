using api.EntityFramework.Contexts;
using api.Exceptions.RepositoryExceptions;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace ProfileAuthorization
{
    public class PermissionService : IPermissionService, IAsyncDisposable
    {
        private readonly MySQLContext _dbContext;

        public PermissionService(IDbContextFactory<MySQLContext> dbContextFactory)
        {
            _dbContext = dbContextFactory.CreateDbContext();
        }

        public ValueTask DisposeAsync()
        {
            return _dbContext.DisposeAsync();
        }

        public PermissionSet GetProfilePermissions(
            VerificationOptions verificationOptions)
        {
            PermissionSet permissionSet = new();
            string rawPermissions;

            var profile = _dbContext.Profiles
                    .Include(p => p.OrganizationRelation)
                    .Include(p => p.GroupRelations)
                    .FirstOrDefault(p => p.Id == verificationOptions.ProfileId);
            if (profile is null)
            {
                throw new EntityNotFoundException(nameof(Profile));
            }

            if (verificationOptions.VerificationLevels.Contains(PermissionLevel.PROFILE_ORGANIZATION))
            {
                rawPermissions = profile.OrganizationRelation.Permissions;

                permissionSet.AddPermissions(PermissionLevel.PROFILE_ORGANIZATION, rawPermissions);
            }
            if (verificationOptions.VerificationLevels.Contains(PermissionLevel.PROFILE_GROUP))
            {
                var groupRelation = profile.GroupRelations
                    .FirstOrDefault(pgr => pgr.GroupId == verificationOptions.GroupId);

                rawPermissions = groupRelation != null ? groupRelation.Permissions : "[]";

                permissionSet.AddPermissions(PermissionLevel.PROFILE_GROUP, rawPermissions);
            }

            return permissionSet;
        }
    }
}
