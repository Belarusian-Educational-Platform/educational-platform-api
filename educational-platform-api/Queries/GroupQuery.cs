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
        [UseFiltering]
        [UseSorting]
        public IEnumerable<Group> GetGroups([Service] IGroupService groupService)
        {
            return groupService.GetGroups();
        }

        [Authorize]
        [GraphQLName("groupById")]
        [UseAccount]
        public Group GetGroup([Service] IGroupService groupService, int id)
        {
            return groupService.GetGroupById(id);
        }

        [Authorize]
        [GraphQLName("myGroups")]
        [UseProfile]
        public IEnumerable<Group> GetMyGroups(
            [Service] IGroupService groupService, 
            [Profile] Profile profile)
        {
            return groupService.GetProfileGroups(profile.Id);
        }

        [Authorize]
        [GraphQLName("myOrganizationGroups")]
        [UseProfile]
        public IEnumerable<Group> GetMyOrganizationGroups(
            [Service] IGroupService groupService, 
            [Profile] Profile profile)
        {
            // SOLVED - AUTHORIZE - view-private-information
            return groupService.GetMyOrganizationGroups(profile.Id);
        }
    }
}
