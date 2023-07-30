using educational_platform_api.DTOs;
using educational_platform_api.Models;
using educational_platform_api.Repositories;

namespace educational_platform_api.Services
{
    public class ProfileService : IProfileService
    {
        private readonly IProfileRepository _profileRepository;
        private readonly IOrganizationRepository _organizationRepository;
        private readonly AutoMapper.IMapper _mapper;

        public ProfileService(IProfileRepository profileRepository,
            IOrganizationRepository organizationRepository,
            AutoMapper.IMapper mapper)
        {
            _profileRepository = profileRepository;
            _organizationRepository = organizationRepository;
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

        public IEnumerable<Profile> GetMyOrganizationProfiles(int profileId)
        {
            var organization = _organizationRepository.GetProfileOrganization(profileId);
            var organizationProfiles = _profileRepository.GetOrganizationProfiles(organization.Id);

            return organizationProfiles;
        }

        public Profile CreateProfile(CreateProfileInput profileInput)
        {
            Profile profile = _mapper.Map<Profile>(profileInput);
            Profile profileEntity = _profileRepository.CreateProfile(profile);

            return profileEntity;
        }

        public void UpdateProfile(UpdateProfileInput profileInput)
        {
            Profile profile = _mapper.Map<Profile>(profileInput);
            _profileRepository.UpdateProfile(profile);
        }

        public void DeleteProfile(int id)
        {
            Profile profile = _profileRepository.GetProfile(id);
            _profileRepository.DeleteProfile(profile);
        }
    }
}
