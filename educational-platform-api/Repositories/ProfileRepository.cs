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
            List<Profile> profiles = _dbContext.Profiles.ToList();

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
            List<Profile> accountProfiles = _dbContext.Profiles
                .Where(x => x.KeycloakId == keycloakId)
                .ToList();

            return accountProfiles;
        }

        public IEnumerable<Profile> GetByOrganizationId(int organizationId)
        {
            var profiles = _dbContext.Profiles
                .Join(_dbContext.ProfileOrganizationRelations,
                    p => p.Id,
                    por => por.ProfileId,
                    (p, por) => new { p, por })
                .Join(_dbContext.Organizations.Where(o => o.Id == organizationId),
                    pp => pp.por.OrganizationId,
                    o => o.Id,
                    (pp, o) => pp.p)
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

        public void Delete(Profile profile)
        {
            try
            {
                _dbContext.Profiles.Remove(profile);
            } catch (Exception ex) 
            {
                throw new EntityDeleteException(nameof(Profile), ex.Message, ex);
            }
        }
    }
}
