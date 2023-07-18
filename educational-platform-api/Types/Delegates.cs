using educational_platform_api.Middlewares.AuthorizeProfile.Policy;

namespace educational_platform_api.Types
{
    public delegate bool AssertionPredicate(Predicate<ProfileAuthorizationPermission> checkRequirement);
}
