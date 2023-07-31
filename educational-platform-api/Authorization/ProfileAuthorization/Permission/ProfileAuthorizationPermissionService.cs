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
            // TODO: OK? WHEN PROFILE IS IN ORGANIZATION AND WANTS TO UPDATE GROUP, BUT NOT THE PARTICIPANT - GROUP_RELATION THROWS AN EXCEPTION 
            if (verificationOptions.VerificationLevels.Contains(ProfileAuthorizationPermissionLevel.PROFILE_ORGANIZATION))
            {
                try
                {
                    var relation = _unitOfWork.ProfileOrganizationRelations
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
                    var relation = _unitOfWork.ProfileGroupRelations
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
                    var relation = _unitOfWork.ProfileSubgroupRelations
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
