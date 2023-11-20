namespace ProfileAuthorization.Data
{
    public static class GroupPermissions
    {
        public static readonly Permission VIEW_PRIVATE_INFORMATION = new(PermissionLevel.PROFILE_GROUP, "view-private-information");
        public static readonly Permission DELETE = new(PermissionLevel.PROFILE_GROUP, "delete");
        public static readonly Permission UPDATE = new(PermissionLevel.PROFILE_GROUP, "update");
        public static readonly Permission EDIT_PROFILES_PERMISSIONS = new(PermissionLevel.PROFILE_GROUP, "edit-profiles-permissions");
    }
}
