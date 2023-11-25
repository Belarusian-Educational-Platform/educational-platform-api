using api.DTOs.Profile;
using api.Exceptions.RepositoryExceptions;
using api.Models;
using Microsoft.EntityFrameworkCore;
using api.EntityFramework.Contexts;
using api.Extensions.EntityFramework;

namespace api.Services
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

        public async Task<int> Create(CreateProfileInput input)
        {
            using var transaction = await _dbContext.Database.BeginTransactionAsync();
            try
            {
                Profile profile = _mapper.Map<Profile>(input);
                Profile profileEntity = (await _dbContext.Profiles.AddAsync(profile)).Entity;
                await _dbContext.SaveChangesAsync();

                ProfileOrganizationRelation organizationRelation = new ProfileOrganizationRelation()
                {
                    ProfileId = profileEntity.Id,
                    OrganizationId = input.OrganizationId,
                    Permissions = "[\"view-private-information\"]"
                };
                await _dbContext.ProfileOrganizationRelations.AddAsync(organizationRelation);
                await _dbContext.SaveChangesAsync();

                await transaction.CommitAsync();

                return profileEntity.Id;
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();

                throw;
            }
        }

   
        public async Task Update(UpdateProfileInput input)
        {
            Profile profile = _mapper.Map<Profile>(input);
            Profile? originalProfile = await _dbContext.Profiles
                .FirstOrDefaultAsync(p => p.Id == input.Id);
            if (originalProfile is null)
            {
                throw new EntityNotFoundException(nameof(Profile));
            }
            ORMExtention.CopyNotNullProperties(profile, originalProfile);

            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            Profile? profile = await _dbContext.Profiles
                .Include(p => p.OrganizationRelation)
                .Include(p => p.GroupRelations)
                .FirstOrDefaultAsync(p => p.Id == id);
            if (profile is null) {
                throw new EntityNotFoundException(nameof(Profile));
            }

            _dbContext.Profiles.Remove(profile);
            await _dbContext.SaveChangesAsync();
        }
    }
}
