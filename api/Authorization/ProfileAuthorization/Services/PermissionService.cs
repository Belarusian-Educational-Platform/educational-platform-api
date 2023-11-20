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

        public PermissionSet GetProfilePermissions(VerificationOptions verificationOptions, Policy policy)
        {
            PermissionSet permissionSet = new();
            string rawPermissions;

            var profile = _dbContext.Profiles
                    .Include(p => p.OrganizationRelation)
                    .Include(p => p.GroupRelations)
                    .FirstOrDefault(p => p.Id == verificationOptions.ProfileId);

            if (policy.VerificationLevels.Contains(PermissionLevel.PROFILE_ORGANIZATION) && profile is not null)
            {
                rawPermissions = profile.OrganizationRelation.Permissions;

                permissionSet.AddPermissions(PermissionLevel.PROFILE_ORGANIZATION, rawPermissions);
            }
            if (policy.VerificationLevels.Contains(PermissionLevel.PROFILE_GROUP) && profile is not null)
            {
                var groupRelation = profile.GroupRelations
                    .FirstOrDefault(pgr => pgr.GroupId == verificationOptions.GroupId);

                rawPermissions = groupRelation != null ? groupRelation.Permissions : "[]";

                permissionSet.AddPermissions(PermissionLevel.PROFILE_GROUP, rawPermissions);
            }
            if (policy.VerificationLevels.Contains(PermissionLevel.KEYCLOAK_ROLE)) {
                var roles = _httpContextAccessor.HttpContext!.User.FindAll(ClaimTypes.Role);
                var permissions = roles.Select(r => new Permission(PermissionLevel.KEYCLOAK_ROLE, r.Value)).ToArray();

                permissionSet.AddPermissions(permissions);
            }

            return permissionSet;
        }
    }
}
