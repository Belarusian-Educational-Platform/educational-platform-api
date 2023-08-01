using AutoMapper;
using educational_platform_api.Contexts;
using educational_platform_api.Exceptions.RepositoryExceptions;
using educational_platform_api.Models;
using Microsoft.EntityFrameworkCore;

namespace educational_platform_api.Repositories
{
    public class ProfileGroupRelationRepository : IProfileGroupRelationRepository
    {
        private readonly MySQLContext _dbContext;

        public ProfileGroupRelationRepository(MySQLContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ProfileGroupRelation Create(ProfileGroupRelation relation)
        {
            ProfileGroupRelation relationEntity;
            try
            {
                relationEntity = _dbContext.ProfileGroupRelations.Add(relation).Entity;
            } catch (Exception ex)
            {
                throw new EntityCreateException(nameof(ProfileGroupRelation), ex.Message, ex);
            }

            return relationEntity;
        }

        public void Delete(params ProfileGroupRelation[] relations)
        {
            try
            {
                _dbContext.ProfileGroupRelations.RemoveRange(relations);
            } catch (Exception ex)
            {
                throw new EntityDeleteException(nameof(ProfileGroupRelation), ex.Message, ex);
            }
        }

        public ProfileGroupRelation GetByEntityIds(int profileId, int groupId)
        {
            ProfileGroupRelation relation;
            try
            {
                relation = _dbContext.ProfileGroupRelations
                    .First(relation => relation.ProfileId == profileId && relation.GroupId == groupId);
            } catch (Exception ex)
            {
                throw new EntityNotFoundException(nameof(ProfileGroupRelation), ex.Message, ex);
            }

            return relation;
        }

        public IEnumerable<ProfileGroupRelation> GetByGroupId(int groupId)
        {
            List<ProfileGroupRelation> relations = _dbContext.ProfileGroupRelations
                .Where(x => x.GroupId == groupId).ToList();

            return relations;
        }

        public IEnumerable<ProfileGroupRelation> GetByProfileId(int profileId)
        {
            List<ProfileGroupRelation> relations = _dbContext.ProfileGroupRelations
                .Where(x => x.ProfileId == profileId).ToList();
            
            return relations;
        }

        public bool TryGetByEntityIds(int profileId, int groupId, out ProfileGroupRelation relation)
        {
            try
            {
                relation = _dbContext.ProfileGroupRelations
                    .First(relation => relation.ProfileId == profileId && relation.GroupId == groupId);

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
