using educational_platform_api.Models;
using educational_platform_api.Services;

namespace educational_platform_api.Queries
{
    [ExtendObjectType(typeof(Query))]
    public class ProfileQuery
    {
        [GraphQLName("profiles")]
        [UseOffsetPaging]
        [UseFiltering]
        [UseSorting]
        public IEnumerable<Profile> GetProfiles([Service] IProfileService profileService)
        {
            return profileService.GetProfiles();
        }

        [GraphQLName("profileById")]
        public Profile GetProfile([Service] IProfileService profileService, int id)
        {
            return profileService.GetProfileById(id);
        }
    }
}
