using educational_platform_api.Models;
using educational_platform_api.Repositories;

namespace educational_platform_api.Services
{
    public class ProfileService : IProfileService
    {
        private readonly IProfileRepository _profileRepository;

        public ProfileService(IProfileRepository profileRepository)
        {
            _profileRepository = profileRepository;
        }

        public Profile GetProfileById(int id)
        {
            return _profileRepository.GetProfile(id);
        }

        public IEnumerable<Profile> GetProfiles()
        {
            return _profileRepository.GetProfiles();
        }
    }
}
