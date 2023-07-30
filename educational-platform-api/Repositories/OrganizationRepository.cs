using educational_platform_api.Contexts;
using educational_platform_api.Exceptions.RepositoryExceptions.EnityNotFoundExceptions;
using educational_platform_api.Models;
using Microsoft.EntityFrameworkCore;

namespace educational_platform_api.Repositories
{
    public class OrganizationRepository : IOrganizationRepository, IAsyncDisposable
    {
        private readonly MySQLContext _dbContext;

        public OrganizationRepository(IDbContextFactory<MySQLContext> dbContextFactory)
        {
            _dbContext = dbContextFactory.CreateDbContext();
        }

        public ValueTask DisposeAsync()
        {
            return _dbContext.DisposeAsync();
        }

        private void Save()
        {
            _dbContext.SaveChanges();
        }

        public IEnumerable<Organization> GetOrganizations()
        {
            List<Organization> organizations = _dbContext.Organizations.ToList();

            return organizations;
        }

        public Organization GetOrganization(int id)
        {
            Organization organization;
            try
            {
                organization = _dbContext.Organizations.First(x => x.Id == id);
            } catch(Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

            return organization;
        }

        public Organization GetProfileOrganization(int profileId)
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
                throw new Exception(ex.Message, ex);
            }
            

            return organization;
        }

        public Organization CreateOrganization(Organization organization)
        {
            Organization organizationEntity;
            try
            {
                organizationEntity = _dbContext.Organizations.Add(organization).Entity;
                Save();
            } catch(Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

            return organizationEntity;
        }

        public void UpdateOrganization(Organization organization)
        {
            try
            {
                _dbContext.Organizations.Attach(organization);
                _dbContext.Entry(organization).State = EntityState.Modified;
                Save();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public void DeleteOrganization(Organization organization)
        {
            try
            {
                _dbContext.Organizations.Remove(organization);
                Save();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
