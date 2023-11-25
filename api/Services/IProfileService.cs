using api.DTOs.Profile;
using api.Models;

namespace api.Services
{
    public interface IProfileService
    {
        public IQueryable<Profile> GetAll();
        public IQueryable<Profile> GetById(int id);
        public IQueryable<Profile> GetByAccount(string keycloakId);

        public Task<int> Create(CreateProfileInput input);
        public Task Update(UpdateProfileInput input);
        public Task Delete(int id);
    }
}
