using educational_platform_api.Authorization.ProfileAuthorization.Permission;
using educational_platform_api.Exceptions.ProfileAuthorizationExceptions;
using educational_platform_api.Types;

namespace ProfileAuthorization
{
    public class ProfileAuthorizationPolicyVerifier : IProfileAuthorizationPolicyVerifier
    {
        private readonly IProfileAuthorizationPermissionService _permissionService;
        private readonly IProfileAuthorizationVerificationOptionsService _verificationOptionsService;

        public ProfileAuthorizationPolicyVerifier(
            IProfileAuthorizationPermissionService permissionService, 
            IProfileAuthorizationVerificationOptionsService verificationOptionsService)
        {
            _permissionService = permissionService;
            _verificationOptionsService = verificationOptionsService;
        }

        public bool Verify(ProfileAuthorizationPolicy policy,
            ProfileAuthorizationVerificationOptions verificationOptions)
        {
            if (!verificationOptions.VerificationLevels.SetEquals(policy.VerificationLevels))
            {
                throw new ProvidedAndRequestedPermissionsMismatchException();
            }
            if (!_verificationOptionsService.CheckOrganizationСorrespondence(verificationOptions))
            {
                throw new ProvidedEntitiesOrganizationNotCorrespondsException();
            }

            var profilePermissions = _permissionService.GetProfilePermissions(verificationOptions);


            foreach (ProfileAuthorizationPermission requirement in policy.Requierements)
            {
                if (!profilePermissions.HasPermission(requirement))
                {
                    return false;
                }
            }

            foreach (AssertionPredicate assertion in policy.Assertions)
            {
                if (!assertion(profilePermissions.HasPermission))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
