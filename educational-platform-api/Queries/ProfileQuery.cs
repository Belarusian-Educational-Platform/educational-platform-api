using educational_platform_api.Middlewares.UseAccount;
using educational_platform_api.Middlewares.UseProfile;
using educational_platform_api.Models;
using educational_platform_api.Services;
using HotChocolate.Authorization;

namespace educational_platform_api.Queries
{
    [ExtendObjectType(typeof(Query))]
    public class ProfileQuery
    {
        [Authorize]
        [GraphQLName("profiles")]
        [UseOffsetPaging]
        [UseFiltering]
        [UseSorting]
        public IEnumerable<Profile> GetProfiles([Service] IProfileService profileService)
        {
            return profileService.GetProfiles();
        }

        [Authorize]
        [GraphQLName("profileById")]
        public Profile GetProfile([Service] IProfileService profileService, int id)
        {
            return profileService.GetProfileById(id);
        }

        [Authorize]
        [GraphQLName("myProfiles")]
        [UseAccount]
        public IEnumerable<Profile> GetMyProfiles([Service] IProfileService profileService, 
            [Account] Account account)
        {
            return profileService.GetAccountProfiles(account.KeycloakId!);
        }

        [Authorize]
        [GraphQLName("myActiveProfile")]
        [UseProfile]
        public Profile GetMyProfiles([Service] IProfileService profileService, 
            [Profile] Profile profile)
        {
            return profile;
        }
    }
}
