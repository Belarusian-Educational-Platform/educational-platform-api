using educational_platform_api.DTOs.Organization;
using educational_platform_api.Models;
using educational_platform_api.Repositories;

namespace educational_platform_api.Services
{
    public class OrganizationService : IOrganizationService
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly AutoMapper.IMapper _mapper;

        public OrganizationService(UnitOfWork unitOfWork,
            AutoMapper.IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public IEnumerable<Organization> GetOrganizations()
        {
            return _unitOfWork.Organizations.GetAll();
        }

        public Organization GetOrganization(int id)
        {
            return _unitOfWork.Organizations.GetById(id);
        }

        public Organization GetProfileOrganization(int profileId)
        {
            var organization = _unitOfWork.Organizations.GetByProfile(profileId);

            return organization;
        }

        public Organization CreateOrganization(CreateOrganizationInput input)
        {
            var organization = _mapper.Map<Organization>(input);
            var organizationEntity = _unitOfWork.Organizations.Create(organization);
            _unitOfWork.Save();
            return organizationEntity;
        }

        public void UpdateOrganization(UpdateOrganizationInput input)
        {
            var organization = _mapper.Map<Organization>(input);
            _unitOfWork.Organizations.Update(organization);
            _unitOfWork.Save();
        }

        public void DeleteOrganization(int id) // TODO: DELETE ALL!!!!
        {
            var organization = _unitOfWork.Organizations.GetById(id);
            _unitOfWork.Organizations.Delete(organization);
            _unitOfWork.Save();
        }

        public bool CheckProfileInOrganization(int profileId, int organizationId)
        {
            return _unitOfWork.ProfileOrganizationRelations
                .TryGetByEntityIds(profileId, organizationId, out ProfileOrganizationRelation relation);
        }
    }
}
