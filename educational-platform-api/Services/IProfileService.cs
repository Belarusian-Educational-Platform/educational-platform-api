using educational_platform_api.DTOs.Profile;
using educational_platform_api.Models;

namespace educational_platform_api.Services
{
    public interface IProfileService
    {
        public IEnumerable<Profile> GetAllProfiles();
        public Profile GetProfileById(int id);
        public IEnumerable<Profile> GetAccountProfiles(string keycloakId);
        public Profile GetActiveProfile(string keycloakId);
        public IEnumerable<Profile> GetMyOrganizationProfiles(int profileId);
        public IEnumerable<Profile> GetGroupProfiles(int groupId);

        public Profile CreateProfile(CreateProfileInput input);
        public void UpdateProfile(UpdateProfileInput input);
        public void DeleteProfile(int id);
    }
}
