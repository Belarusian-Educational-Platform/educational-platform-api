using educational_platform_api.Contexts;
using educational_platform_api.Exceptions.RepositoryExceptions;
using educational_platform_api.Models;

namespace educational_platform_api.Repositories
{
    public class ProfileSubgroupRelationRepository : IProfileSubgroupRelationRepository
    {
        private readonly MySQLContext _dbContext;

        public ProfileSubgroupRelationRepository(MySQLContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ProfileSubgroupRelation Create(ProfileSubgroupRelation relation)
        {
            ProfileSubgroupRelation relationEntity;
            try
            {
                relationEntity = _dbContext.ProfileSubgroupRelations.Add(relation).Entity;
            } catch (Exception ex)
            {
                throw new EntityCreateException(nameof(ProfileSubgroupRelation), ex.Message, ex);
            }

            return relationEntity;
        }

        public void Delete(params ProfileSubgroupRelation[] relations)
        {
            try
            {
                _dbContext.ProfileSubgroupRelations.RemoveRange(relations);
            } catch (Exception ex)
            {
                throw new EntityDeleteException(nameof(ProfileSubgroupRelation), ex.Message, ex);
            }
        }

        public ProfileSubgroupRelation GetByEntityIds(int profileId, int subgroupId)
        {
            ProfileSubgroupRelation relation;
            try
            {
                relation = _dbContext.ProfileSubgroupRelations
                    .First(x => x.ProfileId == profileId 
                        && x.SubgroupId == subgroupId);
            } catch (Exception ex)
            {
                throw new EntityNotFoundException(nameof(ProfileSubgroupRelation), ex.Message, ex);
            }

            return relation;
        }

        public IEnumerable<ProfileSubgroupRelation> GetByGroupId(int groupId)
        {
            var relations = _dbContext.Subgroups
                .Where(s => s.GroupId == groupId)
                .Join(_dbContext.ProfileSubgroupRelations, 
                    s => s.Id, 
                    psr => psr.SubgroupId, 
                    (s, psr) => psr)
                .ToList();

            return relations;
        }

        public IEnumerable<ProfileSubgroupRelation> GetByProfileId(int profileId)
        {
            var relations = _dbContext.ProfileSubgroupRelations
                .Where(x => x.ProfileId == profileId)
                .ToList();

            return relations;
        }

        public IEnumerable<ProfileSubgroupRelation> GetBySubgroupId(int subgroupId)
        {
            var relations = _dbContext.ProfileSubgroupRelations
                .Where(x => x.SubgroupId == subgroupId)
                .ToList();

            return relations;
        }

        public bool TryGetByEntityIds(int profileId, int subgroupId, out ProfileSubgroupRelation relation)
        {
            try
            {
                relation = _dbContext.ProfileSubgroupRelations
                    .First(x => x.ProfileId == profileId
                        && x.SubgroupId == subgroupId);

                return true;
            } catch (Exception ex)
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
