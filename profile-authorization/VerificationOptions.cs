namespace ProfileAuthorization
{
    public class VerificationOptions
    {
        public HashSet<PermissionLevel> VerificationLevels = new();

        public string PolicyName { get; set; }

        public int ProfileId { get; set; }

        public int GroupId { get; set; }

        public void AddPolicy(string policyName)
        {
            PolicyName = policyName;
        }

        public void AddProfile(int id)
        {
            ProfileId = id;
        }

        public void AddGroup(int id)
        {
            GroupId = id;
            VerificationLevels.Add(PermissionLevel.PROFILE_GROUP);
        }

        public void AddOrganization()
        {
            VerificationLevels.Add(PermissionLevel.PROFILE_ORGANIZATION);
        }
    }
}
