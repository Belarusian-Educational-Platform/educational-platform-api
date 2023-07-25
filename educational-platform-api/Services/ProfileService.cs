using educational_platform_api.DTOs;
using educational_platform_api.Models;
using educational_platform_api.Repositories;

namespace educational_platform_api.Services
{
    public class ProfileService : IProfileService
    {
        private readonly IProfileRepository _profileRepository;
        private readonly AutoMapper.IMapper _mapper;

        public ProfileService(IProfileRepository profileRepository, AutoMapper.IMapper mapper)
        {
            _profileRepository = profileRepository;
            _mapper = mapper;
        }

        public Profile GetProfileById(int id)
        {
            return _profileRepository.GetProfile(id);
        }

        public Profile GetActiveProfile(string keycloakId)
        {
            return _profileRepository.GetActiveProfile(keycloakId);
        }

        public IEnumerable<Profile> GetProfiles()
        {
            return _profileRepository.GetProfiles();
        }

        public IEnumerable<Profile> GetAccountProfiles(string keycloakId)
        {
            return _profileRepository.GetAccountProfiles(keycloakId);
        }

        public Profile CreateProfile(CreateProfileInput profileInput)
        {
            Profile profile = _mapper.Map<Profile>(profileInput);
            Profile profileEntity = _profileRepository.CreateProfile(profile);

            return profileEntity;
        }

        public Profile UpdateProfile(UpdateProfileInput profileInput)
        {
            Profile profile = _mapper.Map<Profile>(profileInput);
            Profile profileEntity = _profileRepository.UpdateProfile(profile);

            return profileEntity;
        }

        public bool DeleteProfile(int id)
        {
            return _profileRepository.DeleteProfile(id);
        }
    }
}
