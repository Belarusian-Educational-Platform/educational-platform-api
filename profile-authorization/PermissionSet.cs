using ProfileAuthorization.Exceptions;
using System.Text.Json;

namespace ProfileAuthorization
{
    public class PermissionSet
    {
        private HashSet<Permission> _permissions = new();

        private List<string> ParsePermissions(string rawPermissions)
        {
            try
            {
                List<string> parsedPermissions = JsonSerializer.Deserialize<List<string>>(rawPermissions)!;
                return parsedPermissions;
            }
            catch (Exception ex)
            {
                throw new JSONPermissionsParseException(ex.Message, ex);
            }
        }

        public void AddPermissions(PermissionLevel permissionLevel, string jsonPermissions) 
        {
            List<string> parsedPermissions = ParsePermissions(jsonPermissions);
            foreach (string parsedPermisson in parsedPermissions)
            {
                var permission = new Permission(permissionLevel, parsedPermisson);
                _permissions.Add(permission);
            }
        }

        public void AddPermissions(params Permission[] permissions) {
            foreach(var permission in permissions) {
                _permissions.Add(permission);
            }
        }

        public void Remove(PermissionLevel permissionLevel) {
            _permissions.RemoveWhere(p => p.Level == permissionLevel);
        }

        public bool HasPermission(Permission permission)
        {
            return _permissions.Contains(permission);
        }

        public HashSet<Permission> GetPermissions() 
        { 
            return _permissions; 
        }
    }
}
