using educational_platform_api.DTOs.Profile;
using educational_platform_api.Models;

namespace educational_platform_api.Services
{
    public interface IProfileService
    {
        public IQueryable<Profile> GetAll();
        public IQueryable<Profile> GetById(int id);
        public IQueryable<Profile> GetByAccount(string keycloakId);

        public int Create(CreateProfileInput input);
        public void Update(UpdateProfileInput input);
        public void Delete(int id);
    }
}
