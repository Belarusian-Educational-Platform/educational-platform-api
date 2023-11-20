using ProfileAuthorization.Exceptions;

namespace ProfileAuthorization
{
    public class PolicyVerifier : IPolicyVerifier
    {
        private readonly IPermissionService _permissionService;
        private readonly IVerificationOptionsService _verificationOptionsService;

        public PolicyVerifier(
            IPermissionService permissionService, 
            IVerificationOptionsService verificationOptionsService)
        {
            _permissionService = permissionService;
            _verificationOptionsService = verificationOptionsService;
        }

        public bool Verify(Policy policy,
            VerificationOptions verificationOptions)
        {
            if (!verificationOptions.VerificationLevels.IsSupersetOf(policy.VerificationLevels))
            {
                throw new ProvidedAndRequestedPermissionsMismatchException();
            }
            
            var profilePermissions = _permissionService.GetProfilePermissions(verificationOptions, policy);
            if (!_verificationOptionsService.CheckOrganizationСorrespondence(verificationOptions))
            {
                profilePermissions.Remove(PermissionLevel.PROFILE_ORGANIZATION);
            }

            foreach (Permission requirement in policy.Requierements)
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
