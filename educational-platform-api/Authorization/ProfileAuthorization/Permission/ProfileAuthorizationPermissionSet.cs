using educational_platform_api.Exceptions.ProfileAuthorizationExceptions;
using educational_platform_api.Types.Enums;
using System.Text.Json;

namespace educational_platform_api.Authorization.ProfileAuthorization.Permission
{
    public class ProfileAuthorizationPermissionSet
    {
        private HashSet<ProfileAuthorizationPermission> permissions = new();

        private List<string> ParsePermissions(string rawPermissions)
        {
            try
            {
                List<string> parsedPermissions = JsonSerializer.Deserialize<List<string>>(rawPermissions);
                return parsedPermissions;
            }
            catch (Exception e)
            {
                throw new JSONPermissionsParseException();
            }
        }

        public void AddPermissions(ProfileAuthorizationPermissionLevel permissionLevel, string jsonPermissions) 
        {
            List<string> parsedPermissions = ParsePermissions(jsonPermissions);
            foreach (string parsedPermisson in parsedPermissions)
            {
                var permission = new ProfileAuthorizationPermission(permissionLevel, parsedPermisson);
                permissions.Add(permission);
            }
        }
        public bool HasPermissions(ProfileAuthorizationPermission permission)
        {
            return permissions.Contains(permission);
        }
    }
}
