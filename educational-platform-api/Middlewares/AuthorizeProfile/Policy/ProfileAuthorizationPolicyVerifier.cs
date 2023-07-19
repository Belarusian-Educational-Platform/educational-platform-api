using educational_platform_api.Repositories;
using educational_platform_api.Types;
using educational_platform_api.Types.Enums;
using System.Text.Json;

namespace educational_platform_api.Middlewares.AuthorizeProfile.Policy
{
    public class ProfileAuthorizationPolicyVerifier : IProfileAuthorizationPolicyVerifier
    {
        private readonly IProfileOrganizationRelationRepository _organizationRelationRepository;
        private readonly IProfileGroupRelationRepository _groupRelationRepository;
        private readonly IProfileSubgroupRelationRepository _subgroupRelationRepository;

        public ProfileAuthorizationPolicyVerifier(IProfileOrganizationRelationRepository organizationRelationRepository, 
            IProfileGroupRelationRepository groupRelationRepository, 
            IProfileSubgroupRelationRepository subgroupRelationRepository)
        {
            _organizationRelationRepository = organizationRelationRepository;
            _groupRelationRepository = groupRelationRepository;
            _subgroupRelationRepository = subgroupRelationRepository;
        }

        public bool Verify(ProfileAuthorizationPolicy policy, 
            ProfileAuthorizationVerificationOptions checkOptions) 
        {
            if(!checkOptions.VerificationLevels.SetEquals(policy.VerificationLevels))
            {
                throw new Exception("Provided information is not enough to verify profile requirements");
            }

            foreach (ProfileAuthorizationPermission requirement in policy.Requierements)
            {
                VerifyRequirement(requirement);
            }

            foreach (AssertionPredicate assertion in policy.Assertions)
            {
                assertion(VerifyRequirement);
            }

            return true;
        }

        public List<ProfileAuthorizationPermission> GetProfilePermissions(
            ProfileAuthorizationVerificationOptions checkOptions)
        {
            List<ProfileAuthorizationPermission> permissions = new();

            if (checkOptions.VerificationLevels.Contains(ProfileAuthorizationPermissionLevel.PROFILE_ORGANIZATION))
            {
                string rawPermissions = _organizationRelationRepository
                    .GetPermissions(checkOptions.ProfileId);
                ProcessAndAddPermission(permissions, ProfileAuthorizationPermissionLevel.PROFILE_ORGANIZATION, rawPermissions);
            }
            if (checkOptions.VerificationLevels.Contains(ProfileAuthorizationPermissionLevel.PROFILE_GROUP))
            {
                string rawPermissions = _groupRelationRepository
                    .GetPermissions(checkOptions.ProfileId, checkOptions.GroupId);
                ProcessAndAddPermission(permissions, ProfileAuthorizationPermissionLevel.PROFILE_GROUP, rawPermissions);
            }
            if (checkOptions.VerificationLevels.Contains(ProfileAuthorizationPermissionLevel.PROFILE_SUBGROUP))
            {
                string rawPermissions = _subgroupRelationRepository
                    .GetPermissions(checkOptions.ProfileId, checkOptions.SubgroupId);
                ProcessAndAddPermission(permissions, ProfileAuthorizationPermissionLevel.PROFILE_SUBGROUP, rawPermissions);
            }

            return permissions;
        }

        private void ProcessAndAddPermission(List<ProfileAuthorizationPermission> permissions, 
            ProfileAuthorizationPermissionLevel type, string rawPermissions) // TODO separate by two methods
        {
            List<string> parsedPermissons = JsonSerializer.Deserialize<List<string>>(rawPermissions);

            foreach (string parsedPermisson in parsedPermissons)
            {
                var permission = new ProfileAuthorizationPermission(type, parsedPermisson);
                permissions.Add(permission);
            }
        }

        public bool VerifyRequirement(ProfileAuthorizationPermission requirement)
        {
            return true;
        }
    }
}
