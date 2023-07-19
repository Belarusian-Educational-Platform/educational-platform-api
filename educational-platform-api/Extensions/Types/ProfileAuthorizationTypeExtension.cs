using educational_platform_api.Authorization.ProfileAuthorization.Permission;
using educational_platform_api.Types.Enums;

namespace educational_platform_api.Extensions.Types
{
    public static class ProfileAuthorizationTypeExtension
    {
        public static ProfileAuthorizationPermission ToPermission(
            this (ProfileAuthorizationPermissionLevel level, string shortName) permissionRaw)
        {
            ProfileAuthorizationPermission permission =
                new ProfileAuthorizationPermission(permissionRaw.level, permissionRaw.shortName);

            return permission;
        }
    }
}
