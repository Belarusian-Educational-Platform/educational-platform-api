using educational_platform_api.Authorization.ProfileAuthorization.Permission;
using educational_platform_api.Exceptions;
using educational_platform_api.Repositories;
using educational_platform_api.Types;
using educational_platform_api.Types.Enums;
using System.Text.Json;

namespace educational_platform_api.Authorization.ProfileAuthorization.Policy
{
    public class ProfileAuthorizationPolicyVerifier : IProfileAuthorizationPolicyVerifier
    {
        private readonly IProfileAuthorizationPermissionService _permissionService;
        public ProfileAuthorizationPolicyVerifier(IProfileAuthorizationPermissionService permissionService)
        {
            _permissionService = permissionService;
        }

        public bool Verify(ProfileAuthorizationPolicy policy,
            ProfileAuthorizationVerificationOptions verificationOptions)
        {
            if (!verificationOptions.VerificationLevels.SetEquals(policy.VerificationLevels))
            {
                throw new ProvidedAndRequestedPermissionsMismatchException();
            }

            var profilePermissions = _permissionService.GetProfilePermissions(verificationOptions);


            foreach (ProfileAuthorizationPermission requirement in policy.Requierements)
            {
                if (!profilePermissions.HasPermissions(requirement))
                {
                    return false;
                }
            }

            foreach (AssertionPredicate assertion in policy.Assertions)
            {
                if (!assertion(profilePermissions.HasPermissions))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
