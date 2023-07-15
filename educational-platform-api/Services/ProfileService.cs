using educational_platform_api.Models;
using educational_platform_api.Repositories;

namespace educational_platform_api.Services
{
    public class ProfileService : IProfileService
    {
        private readonly IProfileRepository profileRepository;

        public ProfileService(IProfileRepository profileRepository)
        {
            this.profileRepository = profileRepository;
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
