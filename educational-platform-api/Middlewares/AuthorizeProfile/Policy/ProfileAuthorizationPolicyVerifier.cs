using educational_platform_api.Repositories;

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

        public void GetProfilePermissions()
        {
            throw new NotImplementedException();
        }

        public bool VerifyRequirement(ProfileAuthorizationRequirement requirement)
        {
            return true;
        }
    }
}
