using educational_platform_api.Types.Enums;

namespace educational_platform_api.Middlewares.AuthorizeProfile.Policy
{
    public class ProfileAuthorizationPermission
    {
        public ProfileAuthorizationPermissionType Type { get; set; }
        public string Content { get; set; }

        public ProfileAuthorizationPermission(ProfileAuthorizationPermissionType type, string content)
        {
            Type = type;
            Content = content;
        }
    }
}
