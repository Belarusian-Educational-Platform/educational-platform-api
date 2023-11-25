using api.DTOs.Group;
using api.DTOs.Relations;
using api.EntityFramework.Contexts;
using api.Exceptions.RepositoryExceptions;
using api.Extensions.EntityFramework;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Services
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

        public IQueryable<Group> GetByOrganization(int organizationId)
        {
            return _dbContext.Groups.Where(g => g.OrganizationRelation.OrganizationId == organizationId);
        }

        public async Task<IQueryable<Group>> GetByProfileOrganization(int profileId)
        {
            var organization = await _dbContext.ProfileOrganizationRelations
                .FirstOrDefaultAsync(por => por.ProfileId == profileId);
            return GetByOrganization(organization!.OrganizationId);
        }

        public IQueryable<Group> GetById(int id)
        {
            return _dbContext.Groups.Where(g => g.Id == id);
        }

        public async Task<int> Create(CreateGroupInput input)
        {
            using var transaction = await _dbContext.Database.BeginTransactionAsync();
            try
            {
                Group group = _mapper.Map<Group>(input);
                Group groupEntity = (await _dbContext.Groups.AddAsync(group)).Entity;
                await _dbContext.SaveChangesAsync();

                GroupOrganizationRelation organizationRelation =
                    new()
                    {
                        GroupId = groupEntity.Id,
                        OrganizationId = input.OrganizationId
                    };
                await _dbContext.GroupOrganizationRelations.AddAsync(organizationRelation);
                await _dbContext.SaveChangesAsync();

                await transaction.CommitAsync();

                return groupEntity.Id;
            }
            catch (Exception)
            {
                transaction.Rollback();

                throw;
            }
        }

        public async Task Update(UpdateGroupInput input)
        {
            Group group = _mapper.Map<Group>(input);
            Group? originalGroup = await _dbContext.Groups
                .FirstOrDefaultAsync(g => g.Id == input.Id);

            if (originalGroup is null)
            {
                throw new EntityNotFoundException(nameof(Group));
            }

            ORMExtention.CopyNotNullProperties(group, originalGroup);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            Group? group = await _dbContext.Groups
                .Include(g => g.ProfileRelations)
                .Include(g => g.OrganizationRelation)
                .FirstOrDefaultAsync(g => g.Id == id);
            if (group is null)
            {
                throw new EntityNotFoundException(nameof(Group));
            }

            _dbContext.Groups.Remove(group);
            await _dbContext.SaveChangesAsync();
        }

        public async Task CreateProfileGroupRelation(CreateProfileGroupRelationInput input)
        {
            ProfileGroupRelation relation = _mapper.Map<ProfileGroupRelation>(input);

            await _dbContext.ProfileGroupRelations.AddAsync(relation);
            await _dbContext.SaveChangesAsync(true);
        }

        public async Task DeleteProfileGroupRelation(int profileId, int groupId)
        {
            ProfileGroupRelation? relation = await _dbContext.ProfileGroupRelations
                .FirstOrDefaultAsync(pgr => pgr.ProfileId == profileId && pgr.GroupId == groupId);
            if (relation is null)
            {
                throw new EntityNotFoundException(nameof(ProfileGroupRelation));
            }

            _dbContext.ProfileGroupRelations.Remove(relation);
            await _dbContext.SaveChangesAsync(true);
        }

        public async Task UpdateProfileGroupRelation(UpdateProfileGroupRelationInput input)
        {
            ProfileGroupRelation relation = _mapper.Map<ProfileGroupRelation>(input);

            _dbContext.Entry(relation).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
    }
}
