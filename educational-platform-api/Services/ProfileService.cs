using educational_platform_api.Contexts;
using educational_platform_api.DTOs.Profile;
using educational_platform_api.Exceptions.RepositoryExceptions;
using educational_platform_api.Models;
using Microsoft.EntityFrameworkCore;
using educational_platform_api.Extensions.ORMS;

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

        public int Create(CreateProfileInput input)
        {
            using (var transaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    Profile profile = _mapper.Map<Profile>(input);
                    Profile profileEntity = _dbContext.Profiles.Add(profile).Entity;
                    _dbContext.SaveChanges();

                    ProfileOrganizationRelation organizationRelation = new ProfileOrganizationRelation()
                    {
                        ProfileId = profileEntity.Id,
                        OrganizationId = input.OrganizationId,
                        Permissions = "[\"view-private-information\"]"
                    };
                    _dbContext.ProfileOrganizationRelations.Add(organizationRelation);
                    _dbContext.SaveChanges();

                    transaction.Commit();

                    return profileEntity.Id;
                } catch (Exception ex)
                {
                    transaction.Rollback();

                    throw;
                }
            }
        }

   
        public void Update(UpdateProfileInput input)
        {
        //    Profile originalProfile = GetById(input.Id).FirstOrDefault();
      //      CompleteInputNullProperties(input, originalProfile);
            Profile profile = _mapper.Map<Profile>(input);
            Profile originalProfile = _dbContext.Profiles.FirstOrDefault(p => p.Id == input.Id);
            if (originalProfile is null)
            {
                throw new EntityNotFoundException(nameof(Profile));
            }
            ORMExtention.CopyNotNullProperties(profile, originalProfile);

            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            Profile? profile = _dbContext.Profiles.FirstOrDefault(p => p.Id == id);
            if (profile is null) {
                throw new EntityNotFoundException(nameof(Profile));
            }

            _dbContext.Profiles.Remove(profile);
            _dbContext.SaveChanges();
        }
    }
}
