using api.Authorization.ProfileAuthorization.Permission;
using api.Types.Enums;

namespace api.Extensions.Types
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
