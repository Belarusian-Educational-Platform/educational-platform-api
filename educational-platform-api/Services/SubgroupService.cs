using educational_platform_api.Repositories;

namespace educational_platform_api.Services
{
    public class SubgroupService : ISubgroupService
    {
        private readonly ISubgroupRepository _subgroupRepository;

        public SubgroupService(ISubgroupRepository subgroupRepository)
        {
            _subgroupRepository = subgroupRepository;
        }
    }
}
