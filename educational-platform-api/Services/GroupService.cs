using educational_platform_api.DTOs.Group;
using educational_platform_api.Models;
using educational_platform_api.Repositories;

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
            return _unitOfWork.Groups.GetGroups();
        }

        public Group GetGroupById(int id)
        {
            return _unitOfWork.Groups.GetGroupById(id);
        }

        public IEnumerable<Group> GetProfileGroups(int profileId)
        {
            return _unitOfWork.Groups.GetProfileGroups(profileId);
        }

        public IEnumerable<Group> GetMyOrganizationGroups(int profileId) // TODO: ?
        {
            var organization = _unitOfWork.Organizations.GetProfileOrganization(profileId);
            var organizationGroups =_unitOfWork.Groups.GetOrganizationGroups(organization.Id);

            return organizationGroups;
        }

        public Group CreateGroup(CreateGroupInput input) // TODO: SAFE WAY TO ADD RELATION? GROUP ADD - SUCCESS BUT RELATION ADD - ERROR
        {
            Group group = _mapper.Map<Group>(input);
            Group groupEntity = _unitOfWork.Groups.CreateGroup(group);

            GroupOrganizationRelation relation = new() { 
                GroupId = groupEntity.Id, 
                OrganizationId = input.OrganizationId 
            }; // TODO: ORGANIZATION EXISTS?
            _unitOfWork.GroupOrganizationRelations.CreateRelation(relation);
            _unitOfWork.Save();

            return groupEntity;
        }

        public void UpdateGroup(UpdateGroupInput input)
        {
            Group group = _mapper.Map<Group>(input);
            _unitOfWork.Groups.UpdateGroup(group);
            _unitOfWork.Save();
        }

        public void DeleteGroup(int id)
        {
            Group group = _unitOfWork.Groups.GetGroupById(id);
            _unitOfWork.Groups.DeleteGroup(group);
            _unitOfWork.Save();
        }
    }
}
