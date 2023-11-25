using api.DTOs.Organization;
using api.DTOs.Relations;
using api.EntityFramework.Contexts;
using api.Exceptions.RepositoryExceptions;
using api.Extensions.EntityFramework;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Services
{
    public class OrganizationService : IOrganizationService, IAsyncDisposable
    {
        private readonly MySQLContext _dbContext;
        private readonly AutoMapper.IMapper _mapper;

        public OrganizationService(IDbContextFactory<MySQLContext> dbContextFactory,
            AutoMapper.IMapper mapper)
        {
            _dbContext = dbContextFactory.CreateDbContext();
            _mapper = mapper;
        }

        public ValueTask DisposeAsync()
        {
            return _dbContext.DisposeAsync();
        }

        public IQueryable<Organization> GetAll()
        {
            return _dbContext.Organizations;
        }

        public IQueryable<Organization> GetById(int id)
        {
            return _dbContext.Organizations.Where(o => o.Id == id);
        }

        public async Task<int> Create(CreateOrganizationInput input)
        {
            Organization organization = _mapper.Map<Organization>(input);
            Organization organizationEntity = (await _dbContext.Organizations
                .AddAsync(organization)).Entity;
            await _dbContext.SaveChangesAsync();
            
            return organizationEntity.Id;
        }

        public async Task Update(UpdateOrganizationInput input)
        {
            Organization organization = _mapper.Map<Organization>(input);
            Organization? originalOrganization = await _dbContext.Organizations
                .FirstOrDefaultAsync(o => o.Id == input.Id);
            if (originalOrganization is null)
            {
                throw new EntityNotFoundException(nameof(Organization));
            }
            ORMExtention.CopyNotNullProperties(organization, originalOrganization);

            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            Organization? organization = await _dbContext.Organizations
                .Include(o => o.GroupRelations)
                    .ThenInclude(gor => gor.Group)
                .Include(o => o.ProfileRelations)
                    .ThenInclude(por => por.Profile)
                        .ThenInclude(p => p.GroupRelations)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (organization is null)
            {
                throw new EntityNotFoundException(nameof(Organization));
            }

            List<Profile> profiles = organization.ProfileRelations
                .Select(por => por.Profile)
                .ToList();
            List<Group> groups = organization.GroupRelations
                .Select(gor => gor.Group)
                .ToList();

            _dbContext.Organizations.Remove(organization);
            _dbContext.Groups.RemoveRange(groups);
            _dbContext.Profiles.RemoveRange(profiles);

            await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> CheckProfileInOrganization(int profileId, int organizationId)
        {
            return await _dbContext.ProfileOrganizationRelations
                .AnyAsync(por => por.ProfileId == profileId && 
                    por.OrganizationId == organizationId);
        }

        public async Task UpdateProfileOrganizationRelation(UpdateProfileOrganizationRelationInput input)
        {
            ProfileOrganizationRelation relation = _mapper.Map<ProfileOrganizationRelation>(input);

            _dbContext.Entry(relation).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
    }
}
