using educational_platform_api.Middlewares.AuthorizeProfile;
using educational_platform_api.Middlewares.UseAccount;
using educational_platform_api.Middlewares.UseProfile;
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
        [UseAccount]
        [UseProfile]
        public Group GetGroup([Service] IGroupService groupService,
            [Account] Account account,
            [Profile] Profile profile,
            int id)
        {
            return new Group();
        }
    }
}
