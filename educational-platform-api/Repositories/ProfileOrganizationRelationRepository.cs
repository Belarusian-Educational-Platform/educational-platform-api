using educational_platform_api.Contexts;
using educational_platform_api.Exceptions.RepositoryExceptions;
using educational_platform_api.Models;

namespace educational_platform_api.Repositories
{
    public class ProfileOrganizationRelationRepository : IProfileOrganizationRelationRepository
    {
        private readonly MySQLContext _dbContext;

        public ProfileOrganizationRelationRepository(MySQLContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ProfileOrganizationRelation GetByProfileId(int profileId)
        {
            ProfileOrganizationRelation relation;
            try
            {
                relation = _dbContext.ProfileOrganizationRelations
                    .First(relation => relation.ProfileId == profileId);
            } catch (Exception ex)
            {
                throw new EntityNotFoundException(nameof(ProfileOrganizationRelation), ex.Message, ex);
            }
            
            return relation;
        }

        public bool TryGetByProfileId(int profileId, out ProfileOrganizationRelation relation)
        {
            try
            {
                relation = _dbContext.ProfileOrganizationRelations
                    .First(x => x.ProfileId == profileId);
                return true;
            }
            catch (Exception ex)
            {
                relation = new()
                {
                    Permissions = "[]"
                };
                return false;
            }
        }

        public IEnumerable<ProfileOrganizationRelation> GetByOrgnizationId(int organizationId)
        {
            List<ProfileOrganizationRelation> relations = _dbContext.ProfileOrganizationRelations
                .Where(relation => relation.OrganizationId == organizationId).ToList();

            return relations;
        }

        public ProfileOrganizationRelation Create(ProfileOrganizationRelation relation)
        {
            ProfileOrganizationRelation relationEntity;
            try
            {
                relationEntity = _dbContext.ProfileOrganizationRelations.Add(relation).Entity;
            } catch (Exception ex)
            {
                throw new EntityCreateException(nameof(ProfileOrganizationRelation), ex.Message, ex);
            }

            return relationEntity;
        }

        public void Delete(params ProfileOrganizationRelation[] relations)
        {
            try
            {
                _dbContext.ProfileOrganizationRelations.RemoveRange(relations);
            }
            catch (Exception ex)
            {
                throw new EntityDeleteException(nameof(ProfileOrganizationRelation), ex.Message, ex);
            }
        }

        public bool TryGetByEntityIds(int profileId, int organizationId, out ProfileOrganizationRelation relation)
        {
            try
            {
                relation = _dbContext.ProfileOrganizationRelations
                    .First(x => x.ProfileId == profileId && x.OrganizationId == organizationId);
                return true;
            }
            catch (Exception ex)
            {
                relation = new()
                {
                    Permissions = "[]"
                };
                return false;
            }
        }
    }
}
