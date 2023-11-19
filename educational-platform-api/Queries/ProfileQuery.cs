using educational_platform_api.Authorization.ProfileAuthorization;
using educational_platform_api.Middlewares.UseAccount;
using educational_platform_api.Middlewares.UseProfile;
using educational_platform_api.Models;
using educational_platform_api.Services;
using HotChocolate.Authorization;
using HotChocolate.Data;

namespace educational_platform_api.Queries
{
    [ExtendObjectType(typeof(Query))]
    public class ProfileQuery
    {
        [Authorize]
        [GraphQLName("profiles_admin")]
        [UseOffsetPaging]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Profile> GetProfiles([Service] IProfileService profileService)
        {
            //TODO admin permission
            return profileService.GetAll();
        }

        [Authorize]
        [UseProjection]
        [GraphQLName("profileById")]
        public IQueryable<Profile> GetProfile([Service] IProfileService profileService, int id)
        {
            return profileService.GetById(id);
        }

        [Authorize]
        [GraphQLName("myProfiles")]
        [UseProjection]
        [UseFiltering]
        [UseAccount]
        public IQueryable<Profile> GetMyProfiles(
            [Service] IProfileService profileService, 
            [Account] Account account)
        {
            return profileService.GetByAccount(account.KeycloakId!);
        }
    }
}
