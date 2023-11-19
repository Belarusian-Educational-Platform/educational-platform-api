using api.Authorization.ProfileAuthorization.Permission;

namespace api.Types
{
    public delegate bool AssertionPredicate(Predicate<ProfileAuthorizationPermission> process);
}
