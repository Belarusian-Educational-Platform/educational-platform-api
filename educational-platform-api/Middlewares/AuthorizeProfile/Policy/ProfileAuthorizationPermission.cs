using educational_platform_api.Types.Enums;

namespace educational_platform_api.Middlewares.AuthorizeProfile.Policy
{
    public class ProfileAuthorizationPermission
    {
        public ProfileAuthorizationPermissionLevel Level { get; set; }
        public string ShortName { get; set; }

        public ProfileAuthorizationPermission(ProfileAuthorizationPermissionLevel level, string shortName)
        {
            Level = level;
            ShortName = shortName;
        }
    }
}
