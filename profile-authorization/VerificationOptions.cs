namespace ProfileAuthorization
{
    public class VerificationOptions
    {
        public HashSet<PermissionLevel> VerificationLevels = new();

        public string PolicyName { get; set; }

        public int ProfileId { get; set; }

        public int GroupId { get; set; }

        public void UsePolicy(string policyName)
        {
            PolicyName = policyName;
        }

        public void UseProfile(int id)
        {
            ProfileId = id;
        }

        public void UseGroup(int id)
        {
            GroupId = id;
            VerificationLevels.Add(PermissionLevel.PROFILE_GROUP);
        }

        public void UseOrganization()
        {
            VerificationLevels.Add(PermissionLevel.PROFILE_ORGANIZATION);
        }

        public void UseKeycloak()
        {
            VerificationLevels.Add(PermissionLevel.KEYCLOAK_ROLE);
        }
    }
}
