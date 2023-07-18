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

        private void CheckPolicyCheckOptionsDependencies
            (ProfileAuthorizationCheckOptions checkOptions, ProfileAuthorizationPolicy policy) //TODO rename
        {
            if (!checkOptions._providedInformation.SetEquals(policy._requiredInformation))
            {
                throw new Exception("Provided information is not enough to verify profile requirements");
            }
        }

        public bool Verify(ProfileAuthorizationPolicy policy, ProfileAuthorizationCheckOptions checkOptions) 
        {
            try
            {
                CheckPolicyCheckOptionsDependencies(checkOptions, policy);
            }catch(Exception e)
            {
                return false;
            }
            Profile profile = _profileRepository.GetProfile(checkOptions.ProfileId);

            var providedPermissions = new HashSet<ProfileAuthorizationPermission>(GetProfilePermissions(profile, checkOptions));
            var requiredPermissions = new HashSet<ProfileAuthorizationPermission>(policy._requierements);

            if (!providedPermissions.SetEquals(requiredPermissions))
            {
                return false;
            }

            foreach(AssertionPredicate assertion in policy._assertions)
            {
                continue;
            }

            return true;
        }

        public List<ProfileAuthorizationPermission> GetProfilePermissions(Profile profile, ProfileAuthorizationCheckOptions checkOptions)
        {
            List<ProfileAuthorizationPermission> permissions= new();

            if (checkOptions._providedInformation.Contains(ProfileAuthorizationPermissionType.PROFILE_ORGANIZATION))
            {
                string rawPermissions = _organizationRelationRepository.GetPermissions(profile.Id, profile.OrganizationId);
                List<string> parsedPermissons = JsonSerializer.Deserialize<List<string>>(rawPermissions);
                foreach(string parsedPermisson in parsedPermissons)
                {
                    var permission = new ProfileAuthorizationPermission(ProfileAuthorizationPermissionType.PROFILE_ORGANIZATION, parsedPermisson);
                    permissions.Add(permission);
                }

            }
            if (checkOptions._providedInformation.Contains(ProfileAuthorizationPermissionType.PROFILE_GROUP))
            {
                string rawPermissions = _groupRelationRepository.GetPermissions(profile.Id, checkOptions.GroupId);
                List<string> parsedPermissons = JsonSerializer.Deserialize<List<string>>(rawPermissions);
                foreach (string parsedPermisson in parsedPermissons)
                {
                    var permission = new ProfileAuthorizationPermission(ProfileAuthorizationPermissionType.PROFILE_GROUP, parsedPermisson);
                    permissions.Add(permission);
                }
            }
            if (checkOptions._providedInformation.Contains(ProfileAuthorizationPermissionType.PROFILE_SUBGROUP))
            {
                string rawPermissions = _subgroupRelationRepository.GetPermissions(profile.Id, checkOptions.SubgroupId);
                List<string> parsedPermissons = JsonSerializer.Deserialize<List<string>>(rawPermissions);
                foreach (string parsedPermisson in parsedPermissons)
                {
                    var permission = new ProfileAuthorizationPermission(ProfileAuthorizationPermissionType.PROFILE_SUBGROUP, parsedPermisson);
                    permissions.Add(permission);
                }
            }

            return permissions;
        }

/*        public bool VerifyRequirement(ProfileAuthorizationPermission requirement)
        {
            
        }*/
    }
}
