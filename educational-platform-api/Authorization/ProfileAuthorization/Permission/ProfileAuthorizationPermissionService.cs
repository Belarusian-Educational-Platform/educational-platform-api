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
            string rawPermissions;
            // TODO: OK? WHEN PROFILE IS IN ORGANIZATION AND WANTS TO UPDATE GROUP, BUT NOT THE PARTICIPANT - GROUP_RELATION THROWS AN EXCEPTION 
            if (verificationOptions.VerificationLevels.Contains(ProfileAuthorizationPermissionLevel.PROFILE_ORGANIZATION))
            {
                try
                {
                    var relation = _organizationRelationRepository
                        .GetProfileRelation(verificationOptions.ProfileId);
                    rawPermissions = relation.Permissions;
                } catch (Exception ex)
                {
                    rawPermissions = "[]";
                }

                permissionSet.AddPermissions(ProfileAuthorizationPermissionLevel.PROFILE_ORGANIZATION, rawPermissions);
            }
            if (verificationOptions.VerificationLevels.Contains(ProfileAuthorizationPermissionLevel.PROFILE_GROUP))
            {
                try
                {
                    var relation = _groupRelationRepository
                        .GetRelation(verificationOptions.ProfileId, verificationOptions.GroupId); ;
                    rawPermissions = relation.Permissions;
                } catch (Exception ex)
                {
                    rawPermissions = "[]";
                }

                permissionSet.AddPermissions(ProfileAuthorizationPermissionLevel.PROFILE_GROUP, rawPermissions);
            }
            if (verificationOptions.VerificationLevels.Contains(ProfileAuthorizationPermissionLevel.PROFILE_SUBGROUP))
            {
                try
                {
                    var relation = _subgroupRelationRepository
                        .GetRelation(verificationOptions.ProfileId, verificationOptions.SubgroupId);
                    rawPermissions = relation.Permissions;
                } catch (Exception ex)
                {
                    rawPermissions = "[]";
                }

                permissionSet.AddPermissions(ProfileAuthorizationPermissionLevel.PROFILE_SUBGROUP, rawPermissions);
            }

            return permissionSet;
        }
    }
}
