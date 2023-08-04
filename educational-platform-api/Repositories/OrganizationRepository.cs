using educational_platform_api.Contexts;
using educational_platform_api.Exceptions.RepositoryExceptions;
using educational_platform_api.Models;
using Microsoft.EntityFrameworkCore;

namespace educational_platform_api.Repositories
{
    public class OrganizationRepository : IOrganizationRepository
    {
        private readonly MySQLContext _dbContext;

        public OrganizationRepository(MySQLContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Organization> GetAll()
        {
            var organizations = _dbContext.Organizations.ToList();

            return organizations;
        }

        public Organization GetById(int id)
        {
            Organization organization;
            try
            {
                organization = _dbContext.Organizations.First(x => x.Id == id);
            } catch(Exception ex)
            {
                throw new EntityNotFoundException(nameof(Organization), ex.Message, ex);
            }

            return organization;
        }

        public Organization GetByProfileId(int profileId)
        {
            Organization organization;
            try
            {
                organization = _dbContext.ProfileOrganizationRelations
                    .Where(por => por.ProfileId == profileId)
                    .Join(_dbContext.Organizations,
                        por => por.OrganizationId,
                        o => o.Id,
                        (por, o) => o)
                    .First();
            } catch (Exception ex)
            {
                throw new EntityNotFoundException(nameof(Organization), ex.Message, ex);
            }
            
            return organization;
        }

        public Organization Create(Organization organization)
        {
            Organization organizationEntity;
            try
            {
                organizationEntity = _dbContext.Organizations.Add(organization).Entity;
            } catch(Exception ex)
            {
                throw new EntityCreateException(nameof(Organization), ex.Message, ex);
            }

            return organizationEntity;
        }

        public void Update(Organization organization)
        {
            try
            {
                _dbContext.Organizations.Attach(organization);
                _dbContext.Entry(organization).State = EntityState.Modified;
            }
            catch (Exception ex)
            {
                throw new EntityUpdateException(nameof(Organization), ex.Message, ex);
            }
        }

        public void Delete(Organization organization)
        {
            try
            {
                _dbContext.Organizations.Remove(organization);
            }
            catch (Exception ex)
            {
                throw new EntityDeleteException(nameof(Organization), ex.Message, ex);
            }
        }

        public Organization GetByGroupId(int groupId)
        {
            Organization organization;
            try
            {
                organization = _dbContext.GroupOrganizationRelations
                    .Where(gor => gor.GroupId == groupId)
                    .Join(_dbContext.Organizations, 
                        gor => gor.OrganizationId, 
                        o => o.Id, 
                        (gor, o) => o)
                    .First();
            } catch (Exception ex)
            {
                throw new EntityNotFoundException(nameof(Organization), ex.Message, ex);
            }

            return organization;
        }
    }
}
