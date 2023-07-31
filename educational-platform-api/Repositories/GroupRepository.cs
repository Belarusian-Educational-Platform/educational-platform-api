using educational_platform_api.Contexts;
using educational_platform_api.Exceptions.RepositoryExceptions;
using educational_platform_api.Models;
using Microsoft.EntityFrameworkCore;

namespace educational_platform_api.Repositories
{
    public class GroupRepository : IGroupRepository, IAsyncDisposable
    {
        private readonly MySQLContext _dbContext;

        public GroupRepository(IDbContextFactory<MySQLContext> dbContextFactory)
        {
            _dbContext = dbContextFactory.CreateDbContext();
        }

        private void Save()
        {
            _dbContext.SaveChanges();
        }

        public ValueTask DisposeAsync()
        {
            return _dbContext.DisposeAsync();
        }

        public Group GetGroupById(int id)
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

        public IEnumerable<Group> GetGroups()
        {
            return _dbContext.Groups.ToList();
        }

        public IEnumerable<Group> GetOrganizationGroups(int organizationId)
        {
            List<Group> groups = _dbContext.Groups
                .Join(_dbContext.GroupOrganizationRelations.Where(gor => gor.OrganizationId == organizationId), 
                    g => g.Id, 
                    gor => gor.GroupId, 
                    (g, gor) => g)
                .ToList();

            return groups;
        }

        public IEnumerable<Group> GetProfileGroups(int profileId)
        {
            List<Group> groups = _dbContext.Groups
                .Join(_dbContext.ProfileGroupRelations.Where(pgr => pgr.ProfileId == profileId),
                    g => g.Id,
                    pgr => pgr.GroupId,
                    (g, pgr) => g)
                .ToList();

            return groups;
        }

        public Group CreateGroup(Group group)
        {
            Group groupEntity;
            try
            {
                groupEntity = _dbContext.Groups.Add(group).Entity;
                Save();
            }
            catch (Exception ex)
            {
                throw new EntityCreateException(nameof(Group), ex.Message, ex);
            }

            return groupEntity;
        }

        public void UpdateGroup(Group group)
        {
            try
            {
                _dbContext.Groups.Attach(group);
                _dbContext.Entry(group).State = EntityState.Modified;
                Save();
            }
            catch (Exception ex)
            {
                throw new EntityUpdateException(nameof(Group), ex.Message, ex);
            }
        }

        public void DeleteGroup(Group group)
        {
            try
            {
                _dbContext.Groups.Remove(group);
                Save();
            }
            catch (Exception ex)
            {
                throw new EntityDeleteException(nameof(Group), ex.Message, ex);
            }
        }
    }
}
