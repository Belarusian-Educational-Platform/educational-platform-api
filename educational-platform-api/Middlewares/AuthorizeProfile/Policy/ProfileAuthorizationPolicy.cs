using educational_platform_api.Types;

namespace educational_platform_api.Middlewares.AuthorizeProfile.Policy
{
    public class ProfileAuthorizationPolicy
    {
        public List<ProfileAuthorizationRequirement> _requierements = 
            new List<ProfileAuthorizationRequirement>();

        public List<AssertionPredicate> _assertions =
            new List<AssertionPredicate>();

        public ProfileAuthorizationPolicy() { }

        public ProfileAuthorizationPolicy(List<ProfileAuthorizationRequirement> requierements, 
            List<AssertionPredicate> assertions)
        {
            _requierements = requierements;
            _assertions = assertions;
        }
    }
}
