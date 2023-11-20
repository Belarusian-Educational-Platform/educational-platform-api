﻿using api.DTOs.Group;
using api.DTOs.Relations;
using api.Models;

namespace api.Services
{
    public interface IGroupService
    {
        public IQueryable<Group> GetAll();
        public IQueryable<Group> GetByOrganization(int organizationId);
        public IQueryable<Group> GetByProfileOrganization(int profileId);
        public IQueryable<Group> GetById(int id);

        public int Create(CreateGroupInput input);
        public void Update(UpdateGroupInput input);
        public void Delete(int id);

        public void UpdateProfileGroupRelation(UpdateProfileGroupRelationInput input);

        public bool CheckOrganizationCorrespondence(int profileId, int groupId);
        public void CreateProfileGroupRelation(CreateProfileGroupRelationInput input);
        public void DeleteProfileGroupRelation(int profileId, int groupId);
    }
}