using educational_platform_api.Repositories;
using educational_platform_api.Types.Enums;
using System.Text.Json;

namespace educational_platform_api.Authorization.ProfileAuthorization.Permission
{
    public class ProfileAuthorizationPermissionService : IProfileAuthorizationPermissionService
    {

        private readonly IProfileOrganizationRelationRepository _organizationRelationRepository;
        private readonly IProfileGroupRelationRepository _groupRelationRepository;
        private readonly IProfileSubgroupRelationRepository _subgroupRelationRepository;

        public ProfileAuthorizationPermissionService(
            IProfileOrganizationRelationRepository organizationRelationRepository,
            IProfileGroupRelationRepository groupRelationRepository,
            IProfileSubgroupRelationRepository subgroupRelationRepository)
        {
            _organizationRelationRepository = organizationRelationRepository;
            _groupRelationRepository = groupRelationRepository;
            _subgroupRelationRepository = subgroupRelationRepository;
        }

        public ProfileAuthorizationPermissionSet GetProfilePermissions(
            ProfileAuthorizationVerificationOptions verificationOptions)
        {
            ProfileAuthorizationPermissionSet permissionSet = new();

            if (verificationOptions.VerificationLevels.Contains(ProfileAuthorizationPermissionLevel.PROFILE_ORGANIZATION))
            {
                var relation = _organizationRelationRepository.GetRelation(verificationOptions.ProfileId);
                string rawPermissions = relation.Permissions;

                permissionSet.AddPermissions(ProfileAuthorizationPermissionLevel.PROFILE_ORGANIZATION, rawPermissions);
            }
            if (verificationOptions.VerificationLevels.Contains(ProfileAuthorizationPermissionLevel.PROFILE_GROUP))
            {
                var relation = _groupRelationRepository.GetRelation(verificationOptions.ProfileId, verificationOptions.GroupId); ;
                string rawPermissions = relation.Permissions;

                permissionSet.AddPermissions(ProfileAuthorizationPermissionLevel.PROFILE_GROUP, rawPermissions);
            }
            if (verificationOptions.VerificationLevels.Contains(ProfileAuthorizationPermissionLevel.PROFILE_SUBGROUP))
            {
                var relation = _subgroupRelationRepository.GetRelation(verificationOptions.ProfileId, verificationOptions.SubgroupId);
                string rawPermissions = relation.Permissions;

                permissionSet.AddPermissions(ProfileAuthorizationPermissionLevel.PROFILE_SUBGROUP, rawPermissions);
            }

            return permissionSet;
        }
    }
}
