using educational_platform_api.Repositories;

namespace educational_platform_api.Services
{
    public class SubgroupService : ISubgroupService
    {
        private readonly ISubgroupRepository subgroupRepository;

        public SubgroupService(ISubgroupRepository subgroupRepository)
        {
            this.subgroupRepository = subgroupRepository;
        }
    }
}
