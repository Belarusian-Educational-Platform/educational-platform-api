using educational_platform_api.Repositories;

namespace educational_platform_api.Services
{
    public class SubgroupService : ISubgroupService
    {
        private readonly UnitOfWork _unitOfWork;

        public SubgroupService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}
