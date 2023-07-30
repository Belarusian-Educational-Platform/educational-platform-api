using educational_platform_api.DTOs;
using educational_platform_api.Models;
using educational_platform_api.Repositories;

namespace educational_platform_api.Services
{
    public class OrganizationService : IOrganizationService
    {
        private readonly IOrganizationRepository _organizationRepository;
        private readonly AutoMapper.IMapper _mapper;

        public OrganizationService(IOrganizationRepository organizationRepository, 
            AutoMapper.IMapper mapper)
        {
            _organizationRepository = organizationRepository;
            _mapper = mapper;
        }

        public IEnumerable<Organization> GetOrganizations()
        {
            return _organizationRepository.GetOrganizations();
        }

        public Organization GetOrganization(int id)
        {
            return _organizationRepository.GetOrganization(id);
        }

        public Organization GetProfileOrganization(int profileId)
        {
            var organization = _organizationRepository.GetProfileOrganization(profileId);

            return organization;
        }

        public Organization CreateOrganization(CreateOrganizationInput input)
        {
            var organization = _mapper.Map<Organization>(input);
            return _organizationRepository.CreateOrganization(organization);
        }

        public void UpdateOrganization(UpdateOrganizationInput input)
        {
            var organization = _mapper.Map<Organization>(input);
            _organizationRepository.UpdateOrganization(organization);
        }

        public void DeleteOrganization(int id)
        {
            var organization = _organizationRepository.GetOrganization(id);
            _organizationRepository.DeleteOrganization(organization);
        }
    }
}
