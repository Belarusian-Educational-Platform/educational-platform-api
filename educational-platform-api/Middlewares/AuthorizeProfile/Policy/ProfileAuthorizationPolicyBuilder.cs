using educational_platform_api.Types;

namespace educational_platform_api.Middlewares.AuthorizeProfile.Policy
{
    public class ProfileAuthorizationPolicyBuilder
    {
        List<ProfileAuthorizationRequirement> _requierements =
            new List<ProfileAuthorizationRequirement>();

        List<AssertionPredicate> _assertions =
            new List<AssertionPredicate>();

        public void AddRequirements(params ProfileAuthorizationRequirement[] requirements)
        {
            foreach(var requirement in requirements)
            {
                _requierements.Add(requirement);
            }
        }

        public void RequireAssertion(AssertionPredicate assertion)
        {
            _assertions.Add(assertion);
        }

        public ProfileAuthorizationPolicy Build()
        {
            return new ProfileAuthorizationPolicy(_requierements, _assertions);
        }
    }
}
