using educational_platform_api.Contexts;
using educational_platform_api.DTOs.Group;
using educational_platform_api.DTOs.Relations;
using educational_platform_api.Exceptions.RepositoryExceptions;
using educational_platform_api.Models;
using Microsoft.EntityFrameworkCore;

namespace educational_platform_api.Services
{
    public class GroupService : IGroupService, IAsyncDisposable
    {
        private readonly MySQLContext _dbContext;
        private readonly AutoMapper.IMapper _mapper;

        public GroupService(IDbContextFactory<MySQLContext> dbContextFactory,
            AutoMapper.IMapper mapper)
        {
            _dbContext = dbContextFactory.CreateDbContext();
            _mapper = mapper;
        }

        public ValueTask DisposeAsync()
        {
            return _dbContext.DisposeAsync();
        }

        public IQueryable<Group> GetAll()
        {
            return _dbContext.Groups;
        }

        public IQueryable<Group> GetById(int id)
        {
            return _dbContext.Groups.Where(g => g.Id == id);
        }

        public Group CreateGroup(CreateGroupInput input)
        {
            using (var transaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    var group = _mapper.Map<Group>(input);

                    var groupEntity = _dbContext.Groups.Add(group).Entity;
                    _dbContext.SaveChanges();

                    var organizationRelation = new GroupOrganizationRelation()
                    {
                        GroupId = groupEntity.Id,
                        OrganizationId = input.OrganizationId
                    };
                    _dbContext.GroupOrganizationRelations.Add(organizationRelation);
                    _dbContext.SaveChanges();
                    // TODO: RETURN GETBYID QUERY? OR MAYBE JUST ID?
                    transaction.Commit();

                    return groupEntity;
                } catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new EntityCreateException(nameof(Group), ex.Message, ex); // TODO: OK?
                }
            }
        }

        public void UpdateGroup(UpdateGroupInput input)
        {
            var group = _mapper.Map<Group>(input);
            try
            {
                _dbContext.Entry(group).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new EntityUpdateException(nameof(Group), ex.Message, ex);
            }
        }

        public void DeleteGroup(int id)
        {
            // TODO: OK? OR CREATE EXTENSION METHOD LIKE RemoveById(int id)?
            Group group;
            try
            {
                group = _dbContext.Groups.First(g => g.Id == id);
            }
            catch (Exception ex)
            {
                throw new EntityNotFoundException(nameof(Group), ex.Message, ex);
            }
            try
            {
                _dbContext.Groups.Remove(group);
            }
            catch (Exception ex)
            {
                throw new EntityDeleteException(nameof(Group), ex.Message, ex);
            }
        }

        public bool CheckCanAddProfileToGroup(int profileId, int groupId)
        {
            return _dbContext.ProfileOrganizationRelations
                .Join(_dbContext.GroupOrganizationRelations,
                    por => por.OrganizationId,
                    gor => gor.OrganizationId,
                    (por, gor) => new { por, gor })
                .Any(r => r.por.ProfileId == profileId && r.gor.GroupId == groupId);
        }

        public void CreateProfileGroupRelation(CreateProfileGroupRelationInput input)
        {
            var relation = _mapper.Map<ProfileGroupRelation>(input);
            try
            {
                _dbContext.ProfileGroupRelations.Add(relation);
            } catch(Exception ex)
            {
                throw new EntityCreateException(nameof(ProfileGroupRelation), ex.Message, ex);
            }
        }

        public void DeleteProfileGroupRelation(int profileId, int groupId)
        {
            ProfileGroupRelation relation;
            try
            {
                relation = _dbContext.ProfileGroupRelations
                    .First(pgr => pgr.ProfileId == profileId && pgr.GroupId == groupId);
            }
            catch (Exception ex)
            {
                throw new EntityNotFoundException(nameof(ProfileGroupRelation), ex.Message, ex);
            }
            try
            {
                _dbContext.ProfileGroupRelations.Remove(relation);
            }
            catch (Exception ex)
            {
                throw new EntityDeleteException(nameof(ProfileGroupRelation), ex.Message, ex);
            }
        }
    }
}
