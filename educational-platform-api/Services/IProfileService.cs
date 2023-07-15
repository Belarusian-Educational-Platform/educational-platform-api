using educational_platform_api.Models;
using educational_platform_api.Repositories;

namespace educational_platform_api.Services
{
    public interface IProfileService
    {
        public IEnumerable<Profile> GetProfiles();
        public Profile GetProfileById(int id);
    }
}
