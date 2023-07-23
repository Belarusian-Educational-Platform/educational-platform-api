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

        public IEnumerable<Profile> GetProfiles()
        {
            return _dbContext.Profiles.ToList();
        }

        public Profile GetProfile(int id)
        {
<<<<<<< HEAD
            return _dbContext.Find<Profile>(id);
        }

        public Profile GetActiveProfile(string keycloakId)
        {
            return _dbContext.Profiles.FirstOrDefault(profile => 
                profile.KeycloakId == keycloakId && profile.IsActive);
        }

        public ValueTask DisposeAsync()
        {
            return _dbContext.DisposeAsync();
=======
            Profile profile;
            try 
            {
                profile = dbContext.Find<Profile>(id);
            }
            catch (Exception ex)
            {
                throw new ProfileByIdNotFoundException();
            }
            return profile;
>>>>>>> update-exceptions_and_filters
        }
    }
}
