using api.Middlewares.UseAccount;
using api.Middlewares.UseProfile;
using api.Models;
using api.Services;
using HotChocolate.Authorization;
using ProfileAuthorization;
using ProfileAuthorization.Data;

namespace api.Queries
{
    [ExtendObjectType(typeof(Query))]
    public class ProfileQuery
    {
        [Authorize]
        [GraphQLName("profiles")]
        [UseOffsetPaging]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Profile> GetProfiles([Service] IProfileService profileService,
            [Service] IAuthorizationService authorizationService)
        {
            authorizationService.Authorize(options =>
            {
                options.UsePolicy(Policies.GET_PROFILES);
                options.UseKeycloak();
            });

            return profileService.GetAll();
        }

        [Authorize]
        [UseProjection]
        [GraphQLName("profileById")]
        [UseProfile]
        public IQueryable<Profile> GetProfile([Service] IProfileService profileService,
            [Service] IAuthorizationService authorizationService,
            [Profile] Profile profile,
            int id)
        {
            authorizationService.Authorize(options => {
                options.UsePolicy(Policies.GET_PROFILE_BY_ID);
                options.UseProfile(profile.Id);
                options.UseOrganization();
                options.UseKeycloak();
            });

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
