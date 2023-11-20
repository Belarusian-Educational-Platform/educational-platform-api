namespace ProfileAuthorization.Data
{
    public static class OrganizationPermissions
    {
        public static readonly Permission CREATE_PROFILES = new(PermissionLevel.PROFILE_ORGANIZATION, "create-profiles");
        public static readonly Permission DELETE_PROFILES = new(PermissionLevel.PROFILE_ORGANIZATION, "delete-profiles");
        public static readonly Permission UPDATE = new(PermissionLevel.PROFILE_ORGANIZATION, "update");
        public static readonly Permission EDIT_PROFILES_PERMISSIONS = new(PermissionLevel.PROFILE_ORGANIZATION, "edit-profiles-permissions");
        public static readonly Permission VIEW_GROUPS_PRIVATE_INFORMATION = new(PermissionLevel.PROFILE_ORGANIZATION, "view-groups-private-information");
        public static readonly Permission CREATE_GROUPS = new(PermissionLevel.PROFILE_ORGANIZATION, "create-groups");
        public static readonly Permission DELETE_GROUPS = new(PermissionLevel.PROFILE_ORGANIZATION, "delete-groups");
        public static readonly Permission UPDATE_GROUPS = new(PermissionLevel.PROFILE_ORGANIZATION, "update-groups");
        public static readonly Permission EDIT_GROUP_PROFILES_PERMISSIONS = new(PermissionLevel.PROFILE_ORGANIZATION, "edit-group-profiles-permissions");
        public static readonly Permission VIEW_PRIVATE_INFORMATION = new(PermissionLevel.PROFILE_ORGANIZATION, "view-private-information");
    }
}
