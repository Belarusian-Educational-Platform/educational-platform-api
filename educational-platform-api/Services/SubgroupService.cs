using educational_platform_api.DTOs.Relations;
using educational_platform_api.DTOs.Subgroup;
using educational_platform_api.Models;
using educational_platform_api.Repositories;

namespace educational_platform_api.Services
{
    public class SubgroupService : ISubgroupService
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly AutoMapper.IMapper _mapper;

        public SubgroupService(UnitOfWork unitOfWork, AutoMapper.IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public bool CheckCanAddProfileToSubgroup(int profileId, int subgroupId)
        {
            var subgroup = _unitOfWork.Subgroups.GetById(subgroupId);
            var group = _unitOfWork.Groups.GetById(subgroup.GroupId);
            return _unitOfWork.ProfileGroupRelations
                .TryGetByEntityIds(profileId, group.Id, out ProfileGroupRelation relation);
        }

        public void CreateProfileSubgroupRelation(CreateProfileSubgroupRelationInput input)
        {
            var relation = _mapper.Map<ProfileSubgroupRelation>(input);
            _unitOfWork.ProfileSubgroupRelations.Create(relation);
            _unitOfWork.Save();
        }

        public Subgroup CreateSubgroup(CreateSubgroupInput input)
        {
            var subgroup = _mapper.Map<Subgroup>(input);
            var subgroupEntity = _unitOfWork.Subgroups.Create(subgroup);
            _unitOfWork.Save();

            return subgroupEntity;
        }

        public void DeleteProfileSubgroupRelation(int profileId, int subgroupId)
        {
            var relation = _unitOfWork.ProfileSubgroupRelations
                .GetByEntityIds(profileId, subgroupId);
            _unitOfWork.ProfileSubgroupRelations.Delete(relation);
            _unitOfWork.Save();
        }

        public void DeleteSubgroup(int id)
        {
            var subgroup = _unitOfWork.Subgroups.GetById(id);
            var profileRelations = _unitOfWork.ProfileSubgroupRelations.GetBySubgroupId(id);

            _unitOfWork.Subgroups.Delete(subgroup);
            _unitOfWork.ProfileSubgroupRelations.Delete(profileRelations.ToArray());
            _unitOfWork.Save();
        }

        public IEnumerable<Subgroup> GetGroupSubgroups(int groupId)
        {
            var subgroups = _unitOfWork.Subgroups.GetByGroupId(groupId);

            return subgroups;
        }

        public IEnumerable<Subgroup> GetProfileSubgroups(int profileId)
        {
            var subgroups = _unitOfWork.Subgroups.GetByProfileId(profileId);

            return subgroups;
        }

        public Subgroup GetSubgroupById(int id)
        {
            var subgroup = _unitOfWork.Subgroups.GetById(id);

            return subgroup;
        }

        public IEnumerable<Subgroup> GetAllSubgroups()
        {
            var subgroups = _unitOfWork.Subgroups.GetAll();

            return subgroups;
        }

        public void UpdateSubgroup(UpdateSubgroupInput input)
        {
            var subgroup = _mapper.Map<Subgroup>(input);

            _unitOfWork.Subgroups.Update(subgroup);
            _unitOfWork.Save();
        }
    }
}
