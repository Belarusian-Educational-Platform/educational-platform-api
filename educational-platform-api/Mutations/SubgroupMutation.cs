using educational_platform_api.Models;
using educational_platform_api.Services;

namespace educational_platform_api.Mutations
{
    [ExtendObjectType(typeof(Mutation))]
    public class SubgroupMutation
    {
        [GraphQLName("createSubgroup")]
        public Subgroup CreateSubgroup([Service] ISubgroupService subgroupService, Subgroup subgroup)
        {
            return subgroup;
        }

        [GraphQLName("updateSubgroup")]
        public Subgroup UpdateSubgroup([Service] ISubgroupService subgroupService, Subgroup subgroup)
        {
            return subgroup;
        }

        [GraphQLName("deleteSubgroup")]
        public bool DeleteSubgroup([Service] ISubgroupService subgroupService, int id)
        {
            return true;
        }
    }
}
