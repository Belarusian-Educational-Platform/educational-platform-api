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
            List<Organization> organizations = _dbContext.Organizations.ToList();

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

        public Organization GetByProfile(int profileId)
        {
            Organization organization;
            try
            {
                organization = _dbContext.Organizations
                    .Join(_dbContext.ProfileOrganizationRelations,
                        o => o.Id,
                        por => por.OrganizationId,
                        (o, por) => new { o, por })
                    .Join(_dbContext.Profiles.Where(p => p.Id == profileId),
                        op => op.por.ProfileId,
                        p => p.Id,
                        (op, p) => op.o)
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
    }
}
