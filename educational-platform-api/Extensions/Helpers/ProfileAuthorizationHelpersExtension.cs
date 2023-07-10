using educational_platform_api.Middlewares.AuthorizeProfile.Policy;
using educational_platform_api.Types.Enums;

namespace educational_platform_api.Extensions.Helpers
{
    public static class ProfileAuthorizationHelpersExtension
    {
        public static ProfileAuthorizationRequirement ToRequirement(
            this (ProfileAuthorizationRequirementType type, string content) requirementRaw)
        {
            ProfileAuthorizationRequirement requirement = 
                new ProfileAuthorizationRequirement(requirementRaw.type, requirementRaw.content);

            return requirement;
        }
    }
}
