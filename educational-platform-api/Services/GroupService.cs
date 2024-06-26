﻿using educational_platform_api.DTOs.Group;
using educational_platform_api.DTOs.Relations;
using educational_platform_api.EntityFramework.Contexts;
using educational_platform_api.Exceptions.RepositoryExceptions;
using educational_platform_api.Extensions.EntityFramework;
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

        public IQueryable<Group> GetAll(int organizationId)
        {
            return _dbContext.Groups.Where(g => g.OrganizationRelation.OrganizationId == organizationId);
        }

        public IQueryable<Group> GetAllByProfile(int profileId)
        {
            var organization = _dbContext.ProfileOrganizationRelations.Where(r => r.ProfileId == profileId);
            return GetAll(organization.First().OrganizationId);
        }


        public IQueryable<Group> GetById(int id)
        {
            return _dbContext.Groups.Where(g => g.Id == id);
        }

        public int Create(CreateGroupInput input)
        {
            using (var transaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    Group group = _mapper.Map<Group>(input);
                    Group groupEntity = _dbContext.Groups.Add(group).Entity;
                    _dbContext.SaveChanges();

                    GroupOrganizationRelation organizationRelation = 
                        new GroupOrganizationRelation() {
                            GroupId = groupEntity.Id,
                            OrganizationId = input.OrganizationId
                        };
                    _dbContext.GroupOrganizationRelations.Add(organizationRelation);
                    _dbContext.SaveChanges();

                    transaction.Commit();

                    return groupEntity.Id;
                } catch (Exception ex)
                {
                    transaction.Rollback();

                    throw;
                }
            }
        }

        public void Update(UpdateGroupInput input)
        {
            Group group = _mapper.Map<Group>(input);
            Group originalGroup = _dbContext.Groups.FirstOrDefault(g => g.Id == input.Id);
            if (originalGroup is null)
            {
                throw new EntityNotFoundException(nameof(Group));
            }
            ORMExtention.CopyNotNullProperties(group, originalGroup);
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            Group? group = _dbContext.Groups
                .Include(g => g.ProfileRelations)
                .Include(g => g.OrganizationRelation)
                .FirstOrDefault(g => g.Id == id);
            if (group is null) {
                throw new EntityNotFoundException(nameof(Group));
            }

            _dbContext.Groups.Remove(group);
            _dbContext.SaveChanges();
        }

        public bool CheckOrganizationCorrespondence(int profileId, int groupId)
        {
            return _dbContext.Organizations
                .Include(o => o.ProfileRelations)
                .Include(o => o.GroupRelations)
                .Any(o => o.ProfileRelations.Any(por => por.ProfileId == profileId) && 
                    o.GroupRelations.Any(gor => gor.GroupId == groupId));
        }

        public void CreateProfileGroupRelation(CreateProfileGroupRelationInput input)
        {
            ProfileGroupRelation relation = _mapper.Map<ProfileGroupRelation>(input);

            _dbContext.ProfileGroupRelations.Add(relation);
            _dbContext.SaveChanges(true);
        }

        public void DeleteProfileGroupRelation(int profileId, int groupId)
        {
            ProfileGroupRelation? relation = _dbContext.ProfileGroupRelations
                .FirstOrDefault(pgr => pgr.ProfileId == profileId && pgr.GroupId == groupId);
            if (relation is null)
            {
                throw new EntityNotFoundException(nameof(ProfileGroupRelation));
            }
                
            _dbContext.ProfileGroupRelations.Remove(relation);
            _dbContext.SaveChanges(true);
        }

        public void UpdateProfileGroupRelation(UpdateProfileGroupRelationInput input)
        {
            ProfileGroupRelation relation = _mapper.Map<ProfileGroupRelation>(input);

            _dbContext.Entry(relation).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }
    }
}
