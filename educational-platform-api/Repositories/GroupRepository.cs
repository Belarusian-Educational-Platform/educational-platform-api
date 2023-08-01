using educational_platform_api.Contexts;
using educational_platform_api.Exceptions.RepositoryExceptions;
using educational_platform_api.Models;
using Microsoft.EntityFrameworkCore;

namespace educational_platform_api.Repositories
{
    public class GroupRepository : IGroupRepository
    {
        private readonly MySQLContext _dbContext;

        public GroupRepository(MySQLContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Group GetById(int id)
        {
            Group group;
            try
            {
                group = _dbContext.Groups.First(x => x.Id == id);
            } catch (Exception ex)
            {
                throw new EntityNotFoundException(nameof(Group), ex.Message, ex);
            }

            return group;
        }

        public IEnumerable<Group> GetAll()
        {
            var groups = _dbContext.Groups.ToList();

            return groups;
        }

        public IEnumerable<Group> GetByOrganizationId(int organizationId)
        {
            var groups = _dbContext.GroupOrganizationRelations
                .Where(gor => gor.OrganizationId == organizationId)
                .Join(_dbContext.Groups, 
                    gor => gor.GroupId, 
                    g => g.Id, 
                    (gor, g) => g)
                .ToList();

            return groups;
        }

        public IEnumerable<Group> GetByProfileId(int profileId)
        {
            var groups = _dbContext.ProfileGroupRelations
                .Where(pgr => pgr.ProfileId == profileId)
                .Join(_dbContext.Groups,
                    pgr => pgr.GroupId,
                    g => g.Id,
                    (pgr, g) => g)
                .ToList();

            return groups;
        }

        public Group Create(Group group)
        {
            Group groupEntity;
            try
            {
                groupEntity = _dbContext.Groups.Add(group).Entity;
            }
            catch (Exception ex)
            {
                throw new EntityCreateException(nameof(Group), ex.Message, ex);
            }

            return groupEntity;
        }

        public void Update(Group group)
        {
            try
            {
                _dbContext.Groups.Attach(group);
                _dbContext.Entry(group).State = EntityState.Modified;
            }
            catch (Exception ex)
            {
                throw new EntityUpdateException(nameof(Group), ex.Message, ex);
            }
        }

        public void Delete(params Group[] groups)
        {
            try
            {
                _dbContext.Groups.RemoveRange(groups);
            }
            catch (Exception ex)
            {
                throw new EntityDeleteException(nameof(Group), ex.Message, ex);
            }
        }
    }
}
