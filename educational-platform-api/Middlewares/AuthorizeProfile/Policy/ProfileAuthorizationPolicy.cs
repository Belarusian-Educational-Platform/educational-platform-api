using educational_platform_api.Types;
using educational_platform_api.Types.Enums;

namespace educational_platform_api.Middlewares.AuthorizeProfile.Policy
{
    public class ProfileAuthorizationPolicy
    {
        public List<ProfileAuthorizationRequirement> _requierements = 
            new List<ProfileAuthorizationRequirement>();

        public List<AssertionPredicate> _assertions =
            new List<AssertionPredicate>();

        public HashSet<ProfileAuthorizationRequirementType> _requiredInformation =
            new HashSet<ProfileAuthorizationRequirementType>();

        public ProfileAuthorizationPolicy() { }

        public ProfileAuthorizationPolicy(List<ProfileAuthorizationRequirement> requierements, 
            List<AssertionPredicate> assertions, HashSet<ProfileAuthorizationRequirementType> requiredInformation)
        {
            _requierements = requierements;
            _assertions = assertions;
            _requiredInformation= requiredInformation;
        }
    }
}
