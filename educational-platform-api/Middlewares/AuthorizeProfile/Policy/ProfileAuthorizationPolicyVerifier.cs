using educational_platform_api.Models;
using educational_platform_api.Repositories;
using educational_platform_api.Types;
using educational_platform_api.Types.Enums;
using System.Text.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace educational_platform_api.Middlewares.AuthorizeProfile.Policy
{
    public class ProfileAuthorizationPolicyVerifier : IProfileAuthorizationPolicyVerifier
    {
        private readonly IProfileOrganizationRelationRepository _organizationRelationRepository;
        private readonly IProfileGroupRelationRepository _groupRelationRepository;
        private readonly IProfileSubgroupRelationRepository _subgroupRelationRepository;
        private readonly IProfileRepository _profileRepository;

        public ProfileAuthorizationPolicyVerifier(IProfileOrganizationRelationRepository organizationRelationRepository, 
            IProfileGroupRelationRepository groupRelationRepository, 
            IProfileSubgroupRelationRepository subgroupRelationRepository)
        {
            _organizationRelationRepository = organizationRelationRepository;
            _groupRelationRepository = groupRelationRepository;
            _subgroupRelationRepository = subgroupRelationRepository;
        }

        private bool CheckPolicyCheckOptionsDependencies
            (ProfileAuthorizationPolicy policy, ProfileAuthorizationCheckOptions checkOptions) //TODO rename
        {
            if (!checkOptions._providedInformation.SetEquals(policy._requiredInformation))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool Verify(ProfileAuthorizationPolicy policy, ProfileAuthorizationCheckOptions checkOptions) 
        {
            if(!CheckPolicyCheckOptionsDependencies(policy, checkOptions))
            {
                throw new Exception("Provided information is not enough to verify profile requirements");
            }
   
            var providedPermissions = new HashSet<ProfileAuthorizationPermission>(GetProfilePermissions(checkOptions));
            var requiredPermissions = new HashSet<ProfileAuthorizationPermission>(policy._requierements);

            if (!providedPermissions.SetEquals(requiredPermissions))
            {
                return false;
            }

            foreach(AssertionPredicate assertion in policy._assertions)
            {
                assertion(VerifyRequirement);
            }

            return true;
        }

        public List<ProfileAuthorizationPermission> GetProfilePermissions(ProfileAuthorizationCheckOptions checkOptions)
        {
            List<ProfileAuthorizationPermission> permissions= new();

            if (checkOptions._providedInformation.Contains(ProfileAuthorizationPermissionType.PROFILE_ORGANIZATION))
            {
                string rawPermissions = _organizationRelationRepository.GetPermissions(checkOptions.ProfileId);
                AddPermission(permissions, ProfileAuthorizationPermissionType.PROFILE_ORGANIZATION, rawPermissions);
            }
            if (checkOptions._providedInformation.Contains(ProfileAuthorizationPermissionType.PROFILE_GROUP))
            {
                string rawPermissions = _groupRelationRepository.GetPermissions(checkOptions.ProfileId, checkOptions.GroupId);
                AddPermission(permissions, ProfileAuthorizationPermissionType.PROFILE_GROUP, rawPermissions);
            }
            if (checkOptions._providedInformation.Contains(ProfileAuthorizationPermissionType.PROFILE_SUBGROUP))
            {
                string rawPermissions = _subgroupRelationRepository.GetPermissions(checkOptions.ProfileId, checkOptions.SubgroupId);
                AddPermission(permissions, ProfileAuthorizationPermissionType.PROFILE_GROUP, rawPermissions);
            }

            return permissions;
        }

        private void AddPermission(List<ProfileAuthorizationPermission> permissions, ProfileAuthorizationPermissionType type, string rawPermissions)
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
