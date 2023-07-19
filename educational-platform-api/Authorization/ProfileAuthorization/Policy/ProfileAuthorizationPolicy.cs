using educational_platform_api.Authorization.ProfileAuthorization.Permission;
using educational_platform_api.Types;
using educational_platform_api.Types.Enums;

namespace educational_platform_api.Authorization.ProfileAuthorization.Policy
{
    public class ProfileAuthorizationPolicy
    {
        public List<ProfileAuthorizationPermission> Requierements =
            new List<ProfileAuthorizationPermission>();

        public List<AssertionPredicate> Assertions =
            new List<AssertionPredicate>();

        public HashSet<ProfileAuthorizationPermissionLevel> VerificationLevels =
            new HashSet<ProfileAuthorizationPermissionLevel>();

        public ProfileAuthorizationPolicy(List<ProfileAuthorizationPermission> requierements,
            List<AssertionPredicate> assertions, HashSet<ProfileAuthorizationPermissionLevel> verificationLevels)
        {
            Requierements = requierements;
            Assertions = assertions;
            VerificationLevels = verificationLevels;
        }
    }
}
