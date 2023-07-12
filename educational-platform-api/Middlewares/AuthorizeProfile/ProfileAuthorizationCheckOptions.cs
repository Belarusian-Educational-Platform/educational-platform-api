namespace educational_platform_api.Middlewares.AuthorizeProfile
{
    public class ProfileAuthorizationCheckOptions
    {
        public string PolicyName { get; set; }

        public int ProfileId { get; set; }

        public int GroupId { get; set; }
        public bool WithGroupPermissionsCheck { get; set; }

        public int SubgroupId { get; set; }
        public bool WithSubgroupPermissionsCheck { get; set; }

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
            WithGroupPermissionsCheck = true;
        }

        public void WithSubgroup(int id)
        {
            SubgroupId = id;
            WithSubgroupPermissionsCheck = true;
        }
    }
}
