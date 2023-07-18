using educational_platform_api.Middlewares.AuthorizeProfile.Policy;
using educational_platform_api.Types.Enums;

namespace educational_platform_api.Extensions.Helpers
{
    public static class ProfileAuthorizationHelpersExtension
    {
        public static ProfileAuthorizationPermission ToRequirement(
            this (ProfileAuthorizationPermissionType type, string content) requirementRaw)
        {
            ProfileAuthorizationPermission requirement = 
                new ProfileAuthorizationPermission(requirementRaw.type, requirementRaw.content);

            return requirement;
        }
    }
}
