using educational_platform_api.Repositories;

namespace educational_platform_api.Services
{
    public class OrganizationService : IOrganizationService
    {
        private readonly IOrganizationRepository organizationRepository;

        public OrganizationService(IOrganizationRepository organizationRepository)
        {
            this.organizationRepository = organizationRepository;
        }
    }
}
