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
            return _dbContext.Groups.ToList();
        }

        public IEnumerable<Group> GetByOrgnizationId(int organizationId)
        {
            List<Group> groups = _dbContext.Groups
                .Join(_dbContext.GroupOrganizationRelations.Where(gor => gor.OrganizationId == organizationId), 
                    g => g.Id, 
                    gor => gor.GroupId, 
                    (g, gor) => g)
                .ToList();

            return groups;
        }

        public IEnumerable<Group> GetByProfileId(int profileId)
        {
            List<Group> groups = _dbContext.Groups
                .Join(_dbContext.ProfileGroupRelations.Where(pgr => pgr.ProfileId == profileId),
                    g => g.Id,
                    pgr => pgr.GroupId,
                    (g, pgr) => g)
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

        public void Delete(Group group)
        {
            try
            {
                _dbContext.Groups.Remove(group);
            }
            catch (Exception ex)
            {
                throw new EntityDeleteException(nameof(Group), ex.Message, ex);
            }
        }
    }
}
