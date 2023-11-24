namespace ProfileAuthorization
{
    public class VerificationOptions
    {
        public const int DEFAULT_PROFILE_ID = -1;
        public const int DEFAULT_GROUP_ID = -1;
        public const int DEFAULT_ORGANIZATION_ID = -1;

        public HashSet<PermissionLevel> VerificationLevels = new();
        public int ProfileId = DEFAULT_PROFILE_ID;
        public int GroupId = DEFAULT_GROUP_ID;
        public int OrganizationId = DEFAULT_ORGANIZATION_ID;

        public void UseProfile(int id)
        {
            ProfileId = id;
        }
        public void UseGroup(int id)
        {
            GroupId = id;
            VerificationLevels.Add(PermissionLevel.PROFILE_GROUP);
        }
        public void UseOrganization(int id) {
            OrganizationId = id;
            VerificationLevels.Add(PermissionLevel.PROFILE_ORGANIZATION);
        }
        public void UseOrganization() {
            OrganizationId = DEFAULT_ORGANIZATION_ID;
            VerificationLevels.Add(PermissionLevel.PROFILE_ORGANIZATION);
        }
    }
}
