using educational_platform_api.Models;
using educational_platform_api.Services;

namespace educational_platform_api.Mutations
{
    [ExtendObjectType(typeof(Mutation))]
    public class GroupMutation
    {
        [GraphQLName("createGroup")]
        public Group CreateGroup([Service] IGroupService groupService, Group group)
        {
            return group;
        }

        [GraphQLName("updateGroup")]
        public Group UpdateGroup([Service] IGroupService groupService, Group group)
        {
            return group;
        }

        [GraphQLName("deleteGroup")]
        public bool DeleteGroup([Service] IGroupService groupService, int id)
        {
            return true;
        }
    }
}
