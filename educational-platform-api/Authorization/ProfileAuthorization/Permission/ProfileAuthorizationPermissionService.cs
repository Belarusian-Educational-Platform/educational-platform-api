using educational_platform_api.Models;
using educational_platform_api.Repositories;
using educational_platform_api.Types.Enums;
using System.Text.Json;

namespace educational_platform_api.Authorization.ProfileAuthorization.Permission
{
    public class ProfileAuthorizationPermissionService : IProfileAuthorizationPermissionService
    {

        private readonly UnitOfWork _unitOfWork;

        public ProfileAuthorizationPermissionService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ProfileAuthorizationPermissionSet GetProfilePermissions(
            ProfileAuthorizationVerificationOptions verificationOptions)
        {
            ProfileAuthorizationPermissionSet permissionSet = new();
            string rawPermissions;
            if (verificationOptions.VerificationLevels.Contains(ProfileAuthorizationPermissionLevel.PROFILE_ORGANIZATION))
            {
                _unitOfWork.ProfileOrganizationRelations
                    .TryGetByProfileId(verificationOptions.ProfileId, out ProfileOrganizationRelation relation);
                rawPermissions = relation.Permissions;

                permissionSet.AddPermissions(ProfileAuthorizationPermissionLevel.PROFILE_ORGANIZATION, rawPermissions);
            }
            if (verificationOptions.VerificationLevels.Contains(ProfileAuthorizationPermissionLevel.PROFILE_GROUP))
            {
                _unitOfWork.ProfileGroupRelations
                    .TryGetByEntityIds(verificationOptions.ProfileId, verificationOptions.GroupId, 
                        out ProfileGroupRelation relation);
                rawPermissions = relation.Permissions;

                permissionSet.AddPermissions(ProfileAuthorizationPermissionLevel.PROFILE_GROUP, rawPermissions);
            }
            if (verificationOptions.VerificationLevels.Contains(ProfileAuthorizationPermissionLevel.PROFILE_SUBGROUP))
            {
                _unitOfWork.ProfileSubgroupRelations
                        .TryGetByEntityIds(verificationOptions.ProfileId, verificationOptions.SubgroupId, 
                            out ProfileSubgroupRelation relation);
                rawPermissions = relation.Permissions;

                permissionSet.AddPermissions(ProfileAuthorizationPermissionLevel.PROFILE_SUBGROUP, rawPermissions);
            }

            return permissionSet;
        }
    }
}
