using educational_platform_api.Middlewares.AuthorizeProfile;
using educational_platform_api.Middlewares.AuthorizeProfile.Policy;
using educational_platform_api.Models;
using educational_platform_api.Repositories;

namespace educational_platform_api.Services
{
    public class ProfileService : IProfileService
    {
        private readonly IProfileRepository profileRepository;

        //temp
        private readonly IProfileOrganizationRelationRepository profileOrganizationRelationRepository;
        private readonly IProfileGroupRelationRepository profileGroupRelationRepository;
        private readonly IProfileSubgroupRelationRepository profileSubgroupRelationRepository;

        public ProfileService(IProfileRepository profileRepository,
            IProfileOrganizationRelationRepository profileOrganizationRelationRepository,
            IProfileGroupRelationRepository profileGroupRelationRepository,
            IProfileSubgroupRelationRepository profileSubgroupRelationRepository)
        {
            this.profileRepository = profileRepository;

            //temp
            this.profileOrganizationRelationRepository = profileOrganizationRelationRepository;
            this.profileGroupRelationRepository = profileGroupRelationRepository;
            this.profileSubgroupRelationRepository = profileSubgroupRelationRepository;
        }

        public List<ProfileAuthorizationPermission> GetPermissions(int id)
        {
            Profile profile = GetProfileById(1);
            ProfileAuthorizationCheckOptions checkOptions = new();
            checkOptions.WithProfile(profile.Id);
            checkOptions.WithSubgroup(1);
            checkOptions.WithGroup(1);
            checkOptions.WithOrganization();


            var verifier = new ProfileAuthorizationPolicyVerifier(profileOrganizationRelationRepository, profileGroupRelationRepository, profileSubgroupRelationRepository);
            var permissions = verifier.GetProfilePermissions(checkOptions);

            return permissions;
        }

        public Profile GetProfileById(int id)
        {
            return profileRepository.GetProfile(id);
        }

        public IEnumerable<Profile> GetProfiles()
        {
            return profileRepository.GetProfiles();
        }
    }
}
