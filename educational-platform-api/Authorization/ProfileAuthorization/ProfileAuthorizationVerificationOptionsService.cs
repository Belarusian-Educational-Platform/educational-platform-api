using educational_platform_api.Repositories;
using educational_platform_api.Types.Enums;

namespace educational_platform_api.Authorization.ProfileAuthorization
{
    public class ProfileAuthorizationVerificationOptionsService : IProfileAuthorizationVerificationOptionsService
    {
        private readonly UnitOfWork _unitOfWork;

        public ProfileAuthorizationVerificationOptionsService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public bool CheckOrganizationСorrespondence(ProfileAuthorizationVerificationOptions options)
        {
            bool checkResult = true;
            var profileOrganizationId = _unitOfWork.Organizations.GetByProfileId(options.ProfileId).Id;
            
            if (options.VerificationLevels.Contains(ProfileAuthorizationPermissionLevel.PROFILE_GROUP))
            {
                checkResult = _unitOfWork.Organizations
                    .GetByGroupId(options.GroupId).Id
                    .Equals(profileOrganizationId);
            }

            return checkResult;
        }
    }
}
