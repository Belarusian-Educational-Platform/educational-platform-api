using educational_platform_api.Types.Enums;
using System.Text.Json;

namespace educational_platform_api.Authorization.ProfileAuthorization.Permission
{
    public class ProfileAuthorizationPermissionSet
    {
        private HashSet<ProfileAuthorizationPermission> permissions = new();

        private List<string> ParsePermissions(string rawPermissions)
        {
            List<string> parsedPermissions = JsonSerializer.Deserialize<List<string>>(rawPermissions);//Exception???
            return parsedPermissions;
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

        public bool HasPermission(ProfileAuthorizationPermission permission)
        {
            return permissions.Contains(permission);
        }

        public HashSet<ProfileAuthorizationPermission> GetPermissions() 
        { 
            return permissions; 
        }
    }
}
