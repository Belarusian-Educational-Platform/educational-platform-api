using educational_platform_api.Models;
using educational_platform_api.Services;
using educational_platform_api.Middlewares.AuthorizeProfile.Policy;
using Microsoft.Extensions.Options;

namespace educational_platform_api.Queries
{
    [ExtendObjectType(typeof(Query))]
    public class TemporaryTestQuery
    {
        [GraphQLName("permissions")]
        [UseOffsetPaging]
        [UseFiltering]
        [UseSorting]
        public List<ProfileAuthorizationPermission> GetPermisson([Service] IProfileService profileService)
        {
            return profileService.GetPermissions(1);
        }

    }
}
