using educational_platform_api.Types.Enums;

namespace educational_platform_api.Authorization.ProfileAuthorization
{
    public class ProfileAuthorizationVerificationOptions
    {
        public HashSet<ProfileAuthorizationPermissionLevel> VerificationLevels = new();

        public string PolicyName { get; set; }

        public int ProfileId { get; set; }

        public int GroupId { get; set; }

        public int SubgroupId { get; set; }

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
            VerificationLevels.Add(ProfileAuthorizationPermissionLevel.PROFILE_GROUP);
        }

        public void AddSubgroup(int id)
        {
            SubgroupId = id;
            VerificationLevels.Add(ProfileAuthorizationPermissionLevel.PROFILE_SUBGROUP);
        }
        public void AddOrganization()
        {
            VerificationLevels.Add(ProfileAuthorizationPermissionLevel.PROFILE_ORGANIZATION);
        }
    }
}
