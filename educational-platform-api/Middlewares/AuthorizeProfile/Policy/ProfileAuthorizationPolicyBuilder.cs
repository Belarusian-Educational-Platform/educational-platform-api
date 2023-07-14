using educational_platform_api.Types;
using educational_platform_api.Types.Enums;

namespace educational_platform_api.Middlewares.AuthorizeProfile.Policy
{
    public class ProfileAuthorizationPolicyBuilder
    {
        List<ProfileAuthorizationRequirement> _requierements = new();

        List<AssertionPredicate> _assertions = new();

        HashSet<ProfileAuthorizationRequirementType> _providedInformation = new();

        public void AddRequirements(params ProfileAuthorizationRequirement[] requirements)
        {
            foreach(var requirement in requirements)
            {
                _requierements.Add(requirement);
            }
        }
        
        private bool SaveRequiredInformation(ProfileAuthorizationRequirement requirement)
        {
            _providedInformation.Add(requirement.Type);
            return true;
        }

        public void RequireAssertion(AssertionPredicate assertion)
        {
            assertion(SaveRequiredInformation);
            _assertions.Add(assertion);
        }

        public ProfileAuthorizationPolicy Build()
        {
            return new ProfileAuthorizationPolicy(_requierements, _assertions, _providedInformation);
        }
    }
}
