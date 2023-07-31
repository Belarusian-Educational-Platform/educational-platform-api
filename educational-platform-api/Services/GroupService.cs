using educational_platform_api.DTOs.Group;
using educational_platform_api.Models;
using educational_platform_api.Repositories;

namespace educational_platform_api.Services
{
    public class GroupService : IGroupService
    {
        private readonly IGroupRepository _groupRepository;
        private readonly IOrganizationRepository _organizationRepository;
        private readonly IGroupOrganizationRelationRepository _organizationRelationRepository; // TODO: NAME?
        private readonly AutoMapper.IMapper _mapper;

        public GroupService(IGroupRepository groupRepository, 
            IOrganizationRepository organizationRepository, 
            IGroupOrganizationRelationRepository organizationRelationRepository,
            AutoMapper.IMapper mapper)
        {
            _groupRepository = groupRepository;
            _organizationRepository = organizationRepository;
            _organizationRelationRepository = organizationRelationRepository;
            _mapper = mapper;
        }

        public IEnumerable<Group> GetGroups()
        {
            return _groupRepository.GetGroups();
        }

        public Group GetGroupById(int id)
        {
            return _groupRepository.GetGroupById(id);
        }

        public IEnumerable<Group> GetProfileGroups(int profileId)
        {
            return _groupRepository.GetProfileGroups(profileId);
        }

        public IEnumerable<Group> GetMyOrganizationGroups(int profileId) // TODO: ?
        {
            var organization = _organizationRepository.GetProfileOrganization(profileId);
            var organizationGroups = _groupRepository.GetOrganizationGroups(organization.Id);

            return organizationGroups;
        }

        public Group CreateGroup(CreateGroupInput input) // TODO: SAFE WAY TO ADD RELATION? GROUP ADD - SUCCESS BUT RELATION ADD - ERROR
        {
            Group group = _mapper.Map<Group>(input);
            Group groupEntity = _groupRepository.CreateGroup(group);

            GroupOrganizationRelation relation = new() { 
                GroupId = groupEntity.Id, 
                OrganizationId = input.OrganizationId 
            }; // TODO: ORGANIZATION EXISTS?
            _organizationRelationRepository.CreateRelation(relation);

            return groupEntity;
        }

        public void UpdateGroup(UpdateGroupInput input)
        {
            Group group = _mapper.Map<Group>(input);
            _groupRepository.UpdateGroup(group);
        }

        public void DeleteGroup(int id)
        {
            Group group = _groupRepository.GetGroupById(id);
            _groupRepository.DeleteGroup(group);
        }
    }
}
