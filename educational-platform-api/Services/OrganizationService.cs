using educational_platform_api.Contexts;
using educational_platform_api.DTOs.Organization;
using educational_platform_api.Exceptions.RepositoryExceptions;
using educational_platform_api.Models;
using Microsoft.EntityFrameworkCore;

namespace educational_platform_api.Services
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

        public int Create(CreateOrganizationInput input)
        {
            Organization organization = _mapper.Map<Organization>(input);
            Organization organizationEntity = _dbContext.Organizations.Add(organization).Entity;
            _dbContext.SaveChanges();
            
            return organizationEntity.Id;
        }

        public void Update(UpdateOrganizationInput input)
        {
            Organization organization = _mapper.Map<Organization>(input);

            _dbContext.Entry(organization).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            Organization? organization = _dbContext.Organizations
                .FirstOrDefault(p => p.Id == id);
            if (organization is null) {
                throw new EntityNotFoundException(nameof(Organization));
            }

            _dbContext.Organizations.Remove(organization);
            _dbContext.SaveChanges();
        }

        public bool CheckProfileInOrganization(int profileId, int organizationId)
        {
            return _dbContext.ProfileOrganizationRelations
                .Any(por => por.ProfileId == profileId && por.OrganizationId == organizationId);
        }
    }
}
