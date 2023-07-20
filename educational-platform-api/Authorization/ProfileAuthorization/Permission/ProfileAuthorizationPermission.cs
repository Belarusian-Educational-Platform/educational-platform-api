using educational_platform_api.Types.Enums;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;

namespace educational_platform_api.Authorization.ProfileAuthorization.Permission
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

        public override bool Equals(object obj)
        {
            if (obj is not ProfileAuthorizationPermission other)
                return false;

            if (ReferenceEquals(obj, this))
                return true;

            return Level == other.Level && ShortName == other.ShortName;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Level, ShortName);
        }
    }
}
