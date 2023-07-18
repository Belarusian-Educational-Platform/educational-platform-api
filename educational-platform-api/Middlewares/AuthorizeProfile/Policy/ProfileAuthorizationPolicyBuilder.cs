using educational_platform_api.Types;
using educational_platform_api.Types.Enums;

namespace educational_platform_api.Middlewares.AuthorizeProfile.Policy
{
    public class ProfileAuthorizationPolicyBuilder
    {
        List<ProfileAuthorizationPermission> Requirements = new();

        List<AssertionPredicate> Assertions = new();

        HashSet<ProfileAuthorizationPermissionLevel> VerificationLevels = new();

        private bool SaveRequiredInformation(ProfileAuthorizationPermission requirement)
        {
            VerificationLevels.Add(requirement.Level);
            return true;
        }

        public void AddRequirements(params ProfileAuthorizationPermission[] requirements)
        {
            foreach(var requirement in requirements)
            {
                Requirements.Add(requirement);
            }
        }

        public void RequireAssertion(AssertionPredicate assertion)
        {
            assertion(SaveRequiredInformation);
            Assertions.Add(assertion);
        }

        public ProfileAuthorizationPolicy Build()
        {
            return new ProfileAuthorizationPolicy(Requirements, Assertions, VerificationLevels);
        }
    }
}
