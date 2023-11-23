using System.Security.Claims;
using api.EntityFramework.Contexts;
using api.Exceptions.RepositoryExceptions;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace ProfileAuthorization
{
    public class PermissionService : IPermissionService, IAsyncDisposable
    {
        private readonly MySQLContext _dbContext;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public PermissionService(IDbContextFactory<MySQLContext> dbContextFactory, IHttpContextAccessor httpContextAccessor)
        {
            _dbContext = dbContextFactory.CreateDbContext();
            _httpContextAccessor = httpContextAccessor;
        }

        public ValueTask DisposeAsync()
        {
            return _dbContext.DisposeAsync();
        }

        private Permission[] GetKeycloakPermissions(VerificationOptions options)
        {
            var roles = _httpContextAccessor.HttpContext!.User.FindAll(ClaimTypes.Role);

            return roles.Select(r => new Permission(PermissionLevel.KEYCLOAK_ROLE, r.Value)).ToArray();
        }

        public PermissionSet GetProfilePermissions(VerificationOptions options)
        {
            PermissionSet permissionSet = new();
            string rawPermissions;
            /* TODO : remove
            Group - Profile - Organization
            ------------------------------
            1   1   1 - get gr-org perm - can get all
            2   1   1 - nothing - can get org / no gr
            1   1   2 - get gr perm - can get gr / no org
            1   2   1 - nothing - no gr / no org
            1   2   3 - nothing - no gr / no org
            */
            
            var profile = _dbContext.Profiles
                    .Include(p => p.OrganizationRelation)
                    .Include(p => p.GroupRelations)
                    .FirstOrDefault(p => p.Id == options.ProfileId);

            if (options.VerificationLevels.Contains(PermissionLevel.PROFILE_ORGANIZATION) && profile is not null)
            {
                if (options.OrganizationId != VerificationOptions.DEFAULT_ORGANIZATION_ID &&
                    options.OrganizationId != profile.OrganizationRelation.OrganizationId) {
                    rawPermissions = "[]";
                } else {
                    rawPermissions = profile.OrganizationRelation.Permissions;
                }
                permissionSet.AddPermissions(
                    PermissionLevel.PROFILE_ORGANIZATION,
                    rawPermissions
                );
            }

            if (options.VerificationLevels.Contains(PermissionLevel.PROFILE_GROUP) && profile is not null)
            {
                var groupRelation = profile.GroupRelations
                    .FirstOrDefault(pgr => pgr.GroupId == options.GroupId);

                rawPermissions = groupRelation is not null ? groupRelation.Permissions : "[]";
                if (groupRelation is null) {
                    permissionSet.Remove(PermissionLevel.PROFILE_ORGANIZATION);
                }
                permissionSet.AddPermissions(
                    PermissionLevel.PROFILE_GROUP,
                    rawPermissions
                );
            }

            permissionSet.AddPermissions(GetKeycloakPermissions(options));

            return permissionSet;
        }
    }
}
