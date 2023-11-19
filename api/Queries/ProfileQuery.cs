using api.Middlewares.UseAccount;
using api.Models;
using api.Services;
using HotChocolate.Authorization;

namespace api.Queries
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
