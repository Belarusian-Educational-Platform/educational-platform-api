using educational_platform_api.Authorization.ProfileAuthorization.Permission;

namespace educational_platform_api.Types
{
    public delegate bool AssertionPredicate(Predicate<ProfileAuthorizationPermission> process);
}
