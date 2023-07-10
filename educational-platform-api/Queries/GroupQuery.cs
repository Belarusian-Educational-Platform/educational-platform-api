using educational_platform_api.Middlewares.AuthorizeProfile;
using educational_platform_api.Models;
using educational_platform_api.Services;

namespace educational_platform_api.Queries
{
    [ExtendObjectType(typeof(Query))]
    public class GroupQuery
    {
        [GraphQLName("groups")]
        [UseOffsetPaging]
        [UseFiltering]
        [UseSorting]
        public List<Group> GetGroups([Service] IGroupService groupService)
        {
            return new List<Group>();
        }

        [GraphQLName("groupById")]
        [AuthorizeProfile("edit-group")]
        public Group GetGroup([Service] IGroupService groupService, int id)
        {
            return new Group();
        }
    }
}
