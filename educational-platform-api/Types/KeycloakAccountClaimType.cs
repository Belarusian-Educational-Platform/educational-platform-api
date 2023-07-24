using System.Security.Claims;

namespace educational_platform_api.Types
{
    public static class KeycloakAccountClaimType
    {
        public const string Id = ClaimTypes.NameIdentifier;
        public const string Username = "preferred_username";
        public const string FirstName = ClaimTypes.GivenName;
        public const string LastName = ClaimTypes.Surname;
        public const string Surname = "surname";
        public const string Email = ClaimTypes.Email;
        public const string Birthday = "birthday";
    }
}
