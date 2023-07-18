using educational_platform_api.Models;
using educational_platform_api.Repositories;
using educational_platform_api.Middlewares.AuthorizeProfile.Policy;

namespace educational_platform_api.Services
{
    public interface IProfileService
    {
        public IEnumerable<Profile> GetProfiles();
        public Profile GetProfileById(int id);
        public List<ProfileAuthorizationPermission> GetPermissions(int id);

    }
}
