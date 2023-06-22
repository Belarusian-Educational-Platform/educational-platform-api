using educational_platform_api.Models;
using educational_platform_api.Services;

namespace educational_platform_api.Queries
{
    [ExtendObjectType(typeof(Query))]
    public class SubgroupQuery
    {
        [GraphQLName("subgroups")]
        [UseOffsetPaging]
        [UseFiltering]
        [UseSorting]
        public List<Subgroup> GetSubgroups([Service] ISubgroupService subgroupService)
        {
            return new List<Subgroup>();
        }

        [GraphQLName("subgroupById")]
        public Subgroup GetSubgroup([Service] ISubgroupService subgroupService, int id)
        {
            return new Subgroup();
        }
    }
}
