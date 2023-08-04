using educational_platform_api.Contexts;
using educational_platform_api.Exceptions.RepositoryExceptions;
using educational_platform_api.Models;
using Microsoft.EntityFrameworkCore;

namespace educational_platform_api.Repositories
{
    public class ProfileRepository : IProfileRepository
    {
        private readonly MySQLContext _dbContext;

        public ProfileRepository(MySQLContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Profile> GetAll()
        {
            var profiles = _dbContext.Profiles.ToList();

            return profiles;
        }

        public Profile GetById(int id)
        {
            Profile profile;
            try
            {
                profile = _dbContext.Profiles.First(x => x.Id == id);
            }
            catch (Exception ex)
            {
                throw new EntityNotFoundException(nameof(Profile), ex.Message, ex);
            }

            return profile;
        }

        public Profile GetActiveByAccount(string keycloakId)
        {
            Profile profile;
            try
            {
                profile = _dbContext.Profiles.First(x =>
                    x.KeycloakId == keycloakId && x.IsActive);
            }
            catch (Exception ex)
            {
                throw new EntityNotFoundException(nameof(Profile), ex.Message, ex);
            }

            return profile;
        }

        public IEnumerable<Profile> GetByAccount(string keycloakId)
        {
            var profiles = _dbContext.Profiles
                .Where(x => x.KeycloakId == keycloakId)
                .ToList();

            return profiles;
        }

        public IEnumerable<Profile> GetByOrganizationId(int organizationId)
        {
            var profiles = _dbContext.ProfileOrganizationRelations
                .Where(por => por.OrganizationId == organizationId)
                .Join(_dbContext.Profiles, 
                    por => por.ProfileId, 
                    p => p.Id, 
                    (por, p) => p)
                .ToList();

            return profiles;
        }

        public Profile Create(Profile profile)
        {
            Profile profileEntity;
            try
            {
                profileEntity = _dbContext.Profiles.Add(profile).Entity;
            } catch (Exception ex)
            {
                throw new EntityCreateException(nameof(Profile), ex.Message, ex);
            }

            return profileEntity;
        }

        public void Update(Profile profile)
        {
            try
            {
                _dbContext.Profiles.Attach(profile);
                _dbContext.Entry(profile).State = EntityState.Modified;
            } catch (Exception ex)
            {
                throw new EntityUpdateException(nameof(Profile), ex.Message, ex);
            }
        }

        public void Delete(params Profile[] profiles)
        {
            try
            {
                _dbContext.Profiles.RemoveRange(profiles);
            } catch (Exception ex) 
            {
                throw new EntityDeleteException(nameof(Profile), ex.Message, ex);
            }
        }

        public IEnumerable<Profile> GetByGroupId(int groupId)
        {
            var profiles = _dbContext.ProfileGroupRelations
                .Where(pgr => pgr.GroupId == groupId)
                .Join(_dbContext.Profiles, 
                    pgr => pgr.ProfileId, 
                    p => p.Id, 
                    (pgr, p) => p)
                .ToList();

            return profiles;
        }
    }
}
