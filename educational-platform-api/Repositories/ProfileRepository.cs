using educational_platform_api.Contexts;
using educational_platform_api.Exceptions.RepositoryExceptions.EnityNotFoundExceptions;
using educational_platform_api.Exceptions.RepositoryExceptions.EntityCreateException;
using educational_platform_api.Exceptions.RepositoryExceptions.EntityDeleteException;
using educational_platform_api.Exceptions.RepositoryExceptions.EntityUpdateException;
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
                throw new ProfileByIdNotFoundException(ex.Message, ex);
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
                throw new ProfileByIdNotFoundException(ex.Message, ex);
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
            Profile profileEntity;
            try
            {
                profileEntity = _dbContext.Profiles.Add(profile).Entity;
                Save();
            } catch (Exception ex)
            {
                throw new ProfileCreateException(ex.Message, ex);
            }

            return profileEntity;
        }

        public void UpdateProfile(Profile profile)
        {
            try
            {
                _dbContext.Profiles.Attach(profile);
                _dbContext.Entry(profile).State = EntityState.Modified;
                Save();
            } catch (Exception ex)
            {
                throw new ProfileUpdateException(ex.Message, ex);
            }
        }

        public void DeleteProfile(Profile profile)
        {
            try
            {
                _dbContext.Profiles.Remove(profile);
                Save();
            } catch (Exception ex) 
            {
                throw new ProfileDeleteException(ex.Message, ex);
            }
        }
    }
}
