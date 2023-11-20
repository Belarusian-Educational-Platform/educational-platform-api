namespace ProfileAuthorization.Data {
    public static class Policies {
        public const string GET_MY_ORGANIZATION = "GetMyOrganization";
        public const string CREATE_PROFILE = "CreateProfile";
        public const string DELETE_PROFILE = "DeleteProfile";
        public const string GET_MY_ORGANIZATION_PROFILES = "GetMyOrganizationProfiles";
        public const string UPDATE_ORGANIZATION = "UpdateOrganization";
        public const string CREATE_GROUP = "CreateGroup";
        public const string GET_MY_ORGANIZATION_GROUPS = "GetMyOrganizationGroups";
        public const string GET_GROUP_PROFILES = "GetGroupProfiles";
        public const string UPDATE_GROUP = "UpdateGroup";
        public const string DELETE_GROUP = "DeleteGroup";
        public const string UPDATE_PROFILE_GROUP_RELATION = "UpdateProfileGroupRelation";
        public const string UPDATE_PROFILE_ORGANIZATION_RELATION = "UpdateProfileOrganizationRelation";
    }
}
