using educational_platform_api.Contexts;
using educational_platform_api.Exceptions.RepositoryExceptions.EnityNotFoundExceptions;
using educational_platform_api.Models;
using Microsoft.EntityFrameworkCore;

namespace educational_platform_api.Repositories
{
    public class ProfileRepository : IProfileRepository, IAsyncDisposable
    {
        private readonly MySQLContext _dbContext;

        public ProfileRepository(IDbContextFactory<MySQLContext> dbContextFactory)
        {
            _dbContext = dbContextFactory.CreateDbContext();
        }

        public ValueTask DisposeAsync()
        {
            return _dbContext.DisposeAsync();
        }

        private void Save()
        {
            _dbContext.SaveChanges();
        }

        public IEnumerable<Profile> GetProfiles()
        {
            List<Profile> profiles = _dbContext.Profiles.ToList();

            return profiles;
        }

        public Profile GetProfile(int id)
        {
            Profile profile;
            try
            {
                profile = _dbContext.Profiles.First(profile => profile.Id == id);
            }
            catch (Exception ex)
            {
                throw new ProfileByIdNotFoundException();
            }

            return profile;
        }

        public Profile GetActiveProfile(string keycloakId)
        {
            Profile profile;
            try
            {
                profile = _dbContext.Profiles.First(profile =>
                    profile.KeycloakId == keycloakId && profile.IsActive);
            }
            catch (Exception ex)
            {
                throw new ProfileByIdNotFoundException();
            }

            return profile;
        }

        public IEnumerable<Profile> GetAccountProfiles(string keycloakId)
        {
            List<Profile> accountProfiles = _dbContext.Profiles
                .Where(profile => profile.KeycloakId == keycloakId)
                .ToList();

            return accountProfiles;
        }

        public Profile CreateProfile(Profile profile)
        {
            Profile profileEntity = _dbContext.Profiles.Add(profile).Entity;
            Save();

            return profileEntity;
        }

        public Profile UpdateProfile(Profile profile)
        {
            _dbContext.Profiles.Attach(profile);
            _dbContext.Entry(profile).State = EntityState.Modified;
            try
            {
                Save();
            } catch (Exception ex)
            {
                throw new ProfileByIdNotFoundException();
            }

            return profile;
        }

        public bool DeleteProfile(int id)
        {
            Profile profile = GetProfile(id);
            _dbContext.Profiles.Remove(profile);
            Save();

            return true;
        }
    }
}
