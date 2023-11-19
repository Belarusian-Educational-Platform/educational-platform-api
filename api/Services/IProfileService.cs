using api.DTOs.Profile;
using api.Models;

namespace api.Services
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
