using educational_platform_api.DTOs.Group;
using educational_platform_api.DTOs.ProfileGroupRelation;
using educational_platform_api.Models;
using educational_platform_api.Repositories;
using Microsoft.EntityFrameworkCore.Storage;

namespace educational_platform_api.Services
{
    public class GroupService : IGroupService
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly AutoMapper.IMapper _mapper;

        public GroupService(UnitOfWork unitOfWork,
            AutoMapper.IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public IEnumerable<Group> GetGroups()
        {
            return _unitOfWork.Groups.GetAll();
        }

        public Group GetGroupById(int id)
        {
            return _unitOfWork.Groups.GetById(id);
        }

        public IEnumerable<Group> GetProfileGroups(int profileId)
        {
            return _unitOfWork.Groups.GetByProfileId(profileId);
        }

        public IEnumerable<Group> GetMyOrganizationGroups(int profileId)
        {
            var organization = _unitOfWork.Organizations.GetByProfile(profileId);
            var organizationGroups =_unitOfWork.Groups.GetByOrgnizationId(organization.Id);

            return organizationGroups;
        }

        public Group CreateGroup(CreateGroupInput input)
        {
            using (var transaction = _unitOfWork.BeginTransaction())
            {
                try
                {
                    Group group = _mapper.Map<Group>(input);

                    Group groupEntity = _unitOfWork.Groups.Create(group);
                    _unitOfWork.Save();

                    GroupOrganizationRelation relation = new()
                    {
                        GroupId = groupEntity.Id,
                        OrganizationId = input.OrganizationId
                    };
                    _unitOfWork.GroupOrganizationRelations.Create(relation);
                    _unitOfWork.Save();

                    transaction.Commit();

                    return groupEntity;
                } catch (Exception ex)
                {
                    transaction.Rollback();
                    throw ex;
                }
            }
        }

        public void UpdateGroup(UpdateGroupInput input)
        {
            Group group = _mapper.Map<Group>(input);
            _unitOfWork.Groups.Update(group);
            _unitOfWork.Save();
        }

        public void DeleteGroup(int id)
        {
            var group = _unitOfWork.Groups.GetById(id);
            _unitOfWork.Groups.Delete(group);

            var organizationRelation = _unitOfWork.GroupOrganizationRelations.GetByGroupId(id);
            _unitOfWork.GroupOrganizationRelations.Delete(organizationRelation);

            var profileRelations = _unitOfWork.ProfileGroupRelations.GetByGroupId(id);
            _unitOfWork.ProfileGroupRelations.Delete(profileRelations.ToArray());

            var subgroupProfileRelations = _unitOfWork.ProfileSubgroupRelations.GetByGroupId(id);
            _unitOfWork.ProfileSubgroupRelations.Delete(subgroupProfileRelations.ToArray());

            var subgroups = _unitOfWork.Subgroups.GetByGroupId(id);
            _unitOfWork.Subgroups.Delete(subgroups.ToArray());

            _unitOfWork.Save();
        }

        public bool CheckCanAddProfileToGroup(int profileId, int groupId)
        {
            var profileOrganizationRelation = _unitOfWork.ProfileOrganizationRelations
                .GetByProfileId(profileId);
            var groupOrganizationRelation = _unitOfWork.GroupOrganizationRelations
                .GetByGroupId(groupId);

            return profileOrganizationRelation.OrganizationId == groupOrganizationRelation.OrganizationId;
        }

        public void CreateProfileGroupRelation(CreateProfileGroupRelationInput input)
        {
            ProfileGroupRelation relation = _mapper.Map<ProfileGroupRelation>(input);
            _unitOfWork.ProfileGroupRelations.Create(relation);
            _unitOfWork.Save();
        }

        public void DeleteProfileGroupRelation(int profileId, int groupId)
        {
            ProfileGroupRelation relation = 
                _unitOfWork.ProfileGroupRelations.GetByEntityIds(profileId, groupId);
            _unitOfWork.ProfileGroupRelations.Delete(relation);
            _unitOfWork.Save();
        }
    }
}
