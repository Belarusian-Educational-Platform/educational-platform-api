using educational_platform_api.DTOs.Profile;
using educational_platform_api.Models;
using educational_platform_api.Repositories;

namespace educational_platform_api.Services
{
    public class ProfileService : IProfileService
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly AutoMapper.IMapper _mapper;

        public ProfileService(UnitOfWork unitOfWork,
            AutoMapper.IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Profile GetProfileById(int id)
        {
            return _unitOfWork.Profiles.GetProfile(id);
        }

        public Profile GetActiveProfile(string keycloakId)
        {
            return _unitOfWork.Profiles.GetActiveProfile(keycloakId);
        }

        public IEnumerable<Profile> GetProfiles()
        {
            return _unitOfWork.Profiles.GetProfiles();
        }

        public IEnumerable<Profile> GetAccountProfiles(string keycloakId)
        {
            return _unitOfWork.Profiles.GetAccountProfiles(keycloakId);
        }

        public IEnumerable<Profile> GetMyOrganizationProfiles(int profileId)
        {
            var organization = _unitOfWork.Organizations.GetProfileOrganization(profileId);
            var organizationProfiles = _unitOfWork.Profiles.GetOrganizationProfiles(organization.Id);

            return organizationProfiles;
        }

        public Profile CreateProfile(CreateProfileInput input)
        {
            Profile profile = _mapper.Map<Profile>(input);
            Profile profileEntity = _unitOfWork.Profiles.CreateProfile(profile);
            _unitOfWork.Save();

            return profileEntity;
        }

        public void UpdateProfile(UpdateProfileInput input)
        {
            Profile profile = _mapper.Map<Profile>(input);
            _unitOfWork.Profiles.UpdateProfile(profile);
            _unitOfWork.Save();
        }

        public void DeleteProfile(int id)
        {
            Profile profile = _unitOfWork.Profiles.GetProfile(id);
            _unitOfWork.Profiles.DeleteProfile(profile);
            _unitOfWork.Save();
        }
    }
}
