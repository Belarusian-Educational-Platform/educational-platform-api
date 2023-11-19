namespace ProfileAuthorization.Extensions
{
    public static class TypeExtension
    {
        public static Permission ToPermission(
            this (PermissionLevel level, string shortName) permissionRaw)
        {
            Permission permission = new(permissionRaw.level, permissionRaw.shortName);

            return permission;
        }
    }
}
