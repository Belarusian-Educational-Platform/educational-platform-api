using educational_platform_api.Contexts;
using educational_platform_api.DTOs.Profile;
using educational_platform_api.Exceptions.RepositoryExceptions;
using educational_platform_api.Models;
using Microsoft.EntityFrameworkCore;

namespace educational_platform_api.Services
{
    public class ProfileService : IProfileService, IAsyncDisposable
    {
        private readonly MySQLContext _dbContext;
        private readonly AutoMapper.IMapper _mapper;

        public ProfileService(IDbContextFactory<MySQLContext> dbContextFactory,
            AutoMapper.IMapper mapper)
        {
            _dbContext = dbContextFactory.CreateDbContext();
            _mapper = mapper;
        }

        public ValueTask DisposeAsync()
        {
            return _dbContext.DisposeAsync();
        }

        public IQueryable<Profile> GetById(int id)
        {
            return _dbContext.Profiles.Where(p => p.Id == id);
        }

        public IQueryable<Profile> GetAll()
        {
            return _dbContext.Profiles;
        }

        public IQueryable<Profile> GetByAccount(string keycloakId)
        {
            return _dbContext.Profiles.Where(p => p.KeycloakId == keycloakId);
        }

        public Profile CreateProfile(CreateProfileInput input)
        {
            using (var transaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    var profile = _mapper.Map<Profile>(input);
                    var profileEntity = _dbContext.Profiles.Add(profile).Entity;
                    _dbContext.SaveChanges();

                    var organizationRelation = new ProfileOrganizationRelation()
                    {
                        ProfileId = profileEntity.Id,
                        OrganizationId = input.OrganizationId,
                        Permissions = "[]"
                    };
                    _dbContext.ProfileOrganizationRelations.Add(organizationRelation);

                    _dbContext.SaveChanges();
                    // TODO: RETURN GETBYID QUERY? OR MAYBE JUST ID?
                    transaction.Commit();

                    return profileEntity;
                } catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new EntityCreateException(nameof(Profile), ex.Message, ex); // TODO: OK?
                }
            }
        }

        public void UpdateProfile(UpdateProfileInput input)
        {
            var profile = _mapper.Map<Profile>(input);

            // TODO: REFACTOR? OK?
            try
            {
                _dbContext.Entry(profile).State = EntityState.Modified;
                _dbContext.SaveChanges();
            } catch (Exception ex)
            {
                throw new EntityUpdateException(nameof(Profile), ex.Message, ex);
            }
        }

        public void DeleteProfile(int id)
        {
            // TODO: OK? OR CREATE EXTENSION METHOD LIKE RemoveById(int id)?
            Profile profile;
            try
            {
                profile = _dbContext.Profiles.First(p => p.Id == id);
            } catch (Exception ex)
            {
                throw new EntityNotFoundException(nameof(Profile), ex.Message, ex);
            }
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
