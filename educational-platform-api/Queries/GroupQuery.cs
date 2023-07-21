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
        [GraphQLName("groups")]
        [UseOffsetPaging]
        [UseFiltering]
        [UseSorting]
        public List<Group> GetGroups([Service] IGroupService groupService)
        {
            return new List<Group>();
        }

        [GraphQLName("groupById")]
        [Authorize]
        [UseAccount]
        [UseProfile]
        public Group GetGroup([Service] IGroupService groupService, 
            [Service] IProfileAuthorizationService profileAuthService,
            [Account] Account account, [Profile] Profile profile,
            int id)
        {
            /*profileAuthService.AuthorizeProfile(verificationOptions =>
            {
                verificationOptions.AddProfile(profile.Id);
                verificationOptions.AddPolicy("edit-group");
                verificationOptions.AddGroup(id);
            });*/

            return new Group();
        }
    }
}
