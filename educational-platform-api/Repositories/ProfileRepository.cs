using educational_platform_api.Contexts;
using educational_platform_api.Exceptions.RepositoryExceptions.EnityNotFoundExceptions;
using educational_platform_api.Models;
using Microsoft.EntityFrameworkCore;

namespace educational_platform_api.Repositories
{
    public class ProfileRepository : IProfileRepository, IAsyncDisposable
    {
        private readonly MySQLContext dbContext;

        public ProfileRepository(IDbContextFactory<MySQLContext> dbContextFactory)
        {
            dbContext = dbContextFactory.CreateDbContext();
        }

        public IEnumerable<Profile> GetProfiles()
        {
            return dbContext.Profiles.ToList();
        }

        public ValueTask DisposeAsync()
        {
            return dbContext.DisposeAsync();
        }

        public Profile GetProfile(int id)
        {
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
        }
    }
}
