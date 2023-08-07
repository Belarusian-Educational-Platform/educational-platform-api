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

        public Organization CreateOrganization(CreateOrganizationInput input)
        {
            var organization = _mapper.Map<Organization>(input);
            Organization organizationEntity;
            try
            {
                organizationEntity = _dbContext.Organizations.Add(organization).Entity;
                _dbContext.SaveChanges();
            } catch(Exception ex)
            {
                throw new EntityCreateException(nameof(Profile), ex.Message, ex);
            }
            
            // TODO: RETURN GETBYID QUERY? OR MAYBE JUST ID?
            return organizationEntity;
        }

        public void UpdateOrganization(UpdateOrganizationInput input)
        {
            var organization = _mapper.Map<Organization>(input);
            try
            {
                _dbContext.Entry(organization).State = EntityState.Modified;
                _dbContext.SaveChanges();
            } catch (Exception ex)
            {
                throw new EntityUpdateException(nameof(Organization), ex.Message, ex);
            }
        }

        public void DeleteOrganization(int id)
        {
            // TODO: OK? OR CREATE EXTENSION METHOD LIKE RemoveById(int id)?
            Organization organization;
            try
            {
                organization = _dbContext.Organizations.First(p => p.Id == id);
            }
            catch (Exception ex)
            {
                throw new EntityNotFoundException(nameof(Organization), ex.Message, ex);
            }
            try
            {
                _dbContext.Organizations.Remove(organization);
            }
            catch (Exception ex)
            {
                throw new EntityDeleteException(nameof(Organization), ex.Message, ex);
            }
        }

        public bool CheckProfileInOrganization(int profileId, int organizationId)
        {
            return _dbContext.ProfileOrganizationRelations
                .Any(por => por.ProfileId == profileId && por.OrganizationId == organizationId);
        }
    }
}
