<<<<<<< HEAD
﻿using educational_platform_api.Types.Enums;
=======
﻿using educational_platform_api.Exceptions.ProfileAuthorizationExceptions;
using educational_platform_api.Types.Enums;
>>>>>>> update-exceptions_and_filters
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
