using educational_platform_api.Types.Enums;

namespace educational_platform_api.Middlewares.AuthorizeProfile
{
    public class ProfileAuthorizationCheckOptions //TODO rename
    {
        public HashSet<ProfileAuthorizationRequirementType> _providedInformation 
            = new HashSet<ProfileAuthorizationRequirementType>();
        public string PolicyName { get; set; }

        public int ProfileId { get; set; }

        public int GroupId { get; set; }

        public int SubgroupId { get; set; }

        public void WithPolicy(string policyName)
        {
            PolicyName = policyName;
        }

        public void WithProfile(int id)
        {
            ProfileId = id;
        }
        
        public void WithGroup(int id)
        {
            GroupId = id;
            _providedInformation.Add(ProfileAuthorizationRequirementType.PROFILE_GROUP);
        }

        public void WithSubgroup(int id)
        {
            SubgroupId = id;
            _providedInformation.Add(ProfileAuthorizationRequirementType.PROFILE_SUBGROUP);
        }
    }
}
