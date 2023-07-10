using educational_platform_api.Types.Enums;

namespace educational_platform_api.Middlewares.AuthorizeProfile.Policy
{
    public class ProfileAuthorizationRequirement
    {
        public ProfileAuthorizationRequirementType Type { get; set; }
        public string Content { get; set; }

        public ProfileAuthorizationRequirement(ProfileAuthorizationRequirementType type, string content)
        {
            Type = type;
            Content = content;
        }
    }
}
