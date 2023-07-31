using educational_platform_api.Contexts;
using educational_platform_api.Models;
using Microsoft.EntityFrameworkCore;

namespace educational_platform_api.Repositories
{
    public class ProfileSubgroupRelationRepository : IProfileSubgroupRelationRepository
    {
        private readonly MySQLContext _dbContext;

        public ProfileSubgroupRelationRepository(MySQLContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ProfileSubgroupRelation GetRelation(int profileId, int subgroupId)
        {
            ProfileSubgroupRelation relation = _dbContext.ProfileSubgroupRelations
                .First(relation => relation.ProfileId == profileId && relation.SubgroupId == subgroupId);

            return relation;
        }
    }
}
