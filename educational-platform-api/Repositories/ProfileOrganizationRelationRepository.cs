using educational_platform_api.Contexts;
using educational_platform_api.Models;
using Microsoft.EntityFrameworkCore;

namespace educational_platform_api.Repositories
{
    public class ProfileOrganizationRelationRepository : IProfileOrganizationRelationRepository, IAsyncDisposable
    {
        private readonly MySQLContext _dbContext;

        public ProfileOrganizationRelationRepository(IDbContextFactory<MySQLContext> dbContextFactory)
        {
            _dbContext = dbContextFactory.CreateDbContext();
        }

        public ValueTask DisposeAsync()
        {
            return _dbContext.DisposeAsync();
        }

        public ProfileOrganizationRelation GetProfileRelation(int id)
        {
            ProfileOrganizationRelation relation;
            try
            {
                relation = _dbContext.ProfileOrganizationRelations
                    .First(relation => relation.ProfileId == id);
            } catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            
            return relation;
        }

        public IEnumerable<ProfileOrganizationRelation> GetOrganizationRelations(int id)
        {
            List<ProfileOrganizationRelation> relations = _dbContext.ProfileOrganizationRelations
                .Where(relation => relation.OrganizationId == id).ToList();

            return relations;
        }

        public bool CheckRelationExists(int profileId, int organizationId)
        {
            try
            {
                _dbContext.ProfileOrganizationRelations
                    .First(x => x.ProfileId == profileId &&
                        x.OrganizationId == organizationId);
                return true;
            } catch (Exception ex)
            {
                return false;
            }
        }
    }
}
