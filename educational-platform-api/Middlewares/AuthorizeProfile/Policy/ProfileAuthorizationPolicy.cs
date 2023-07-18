using educational_platform_api.Types;
using educational_platform_api.Types.Enums;

namespace educational_platform_api.Middlewares.AuthorizeProfile.Policy
{
    public class ProfileAuthorizationPolicy
    {
        public List<ProfileAuthorizationPermission> _requierements = 
            new List<ProfileAuthorizationPermission>();

        public List<AssertionPredicate> _assertions =
            new List<AssertionPredicate>();

        public HashSet<ProfileAuthorizationPermissionType> _requiredInformation =
            new HashSet<ProfileAuthorizationPermissionType>();

        public ProfileAuthorizationPolicy() { }

        public ProfileAuthorizationPolicy(List<ProfileAuthorizationPermission> requierements, 
            List<AssertionPredicate> assertions, HashSet<ProfileAuthorizationPermissionType> requiredInformation)
        {
            _requierements = requierements;
            _assertions = assertions;
            _requiredInformation= requiredInformation;
        }
    }
}
