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
            return _unitOfWork.Organizations.GetOrganizations();
        }

        public Organization GetOrganization(int id)
        {
            return _unitOfWork.Organizations.GetOrganization(id);
        }

        public Organization GetProfileOrganization(int profileId)
        {
            var organization = _unitOfWork.Organizations.GetProfileOrganization(profileId);

            return organization;
        }

        public Organization CreateOrganization(CreateOrganizationInput input)
        {
            var organization = _mapper.Map<Organization>(input);
            _unitOfWork.Save();
            return _unitOfWork.Organizations.CreateOrganization(organization);
        }

        public void UpdateOrganization(UpdateOrganizationInput input)
        {
            var organization = _mapper.Map<Organization>(input);
            _unitOfWork.Organizations.UpdateOrganization(organization);
            _unitOfWork.Save();
        }

        public void DeleteOrganization(int id)
        {
            var organization = _unitOfWork.Organizations.GetOrganization(id);
            _unitOfWork.Organizations.DeleteOrganization(organization);
            _unitOfWork.Save();
        }

        public bool CheckProfileInOrganization(int profileId, int organizationId)
        {
            return _unitOfWork.ProfileOrganizationRelations
                .CheckRelationExists(profileId, organizationId);
        }
    }
}
