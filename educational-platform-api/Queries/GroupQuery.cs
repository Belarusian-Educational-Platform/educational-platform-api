using educational_platform_api.Authorization.ProfileAuthorization;
using educational_platform_api.Middlewares.UseAccount;
using educational_platform_api.Middlewares.UseProfile;
using educational_platform_api.Models;
using educational_platform_api.Services;
using HotChocolate.Authorization;

namespace educational_platform_api.Queries
{
    [ExtendObjectType(typeof(Query))]
    public class GroupQuery
    {
        [Authorize]
        [GraphQLName("groups")]
        [UseOffsetPaging]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Group> GetGroups([Service] IGroupService groupService)
        {
            return groupService.GetAll();
        }

        [Authorize]
        [GraphQLName("groupById")]
        [UseProjection]
        [UseAccount]
        public IQueryable<Group> GetGroup([Service] IGroupService groupService, int id)
        {
            return groupService.GetById(id);
        }
    }
}
