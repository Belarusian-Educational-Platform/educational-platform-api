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
        public async Task<IQueryable<Profile>> GetProfiles([Service] IProfileService profileService,
            [Service] IAuthorizationService authorizationService)
        {
            await authorizationService.Authorize(
                options => {},
                verifier => verifier.Assert(KeycloakPermissions.ADMIN)
            );

            return profileService.GetAll();
        }

        [Authorize]
        [UseProjection]
        [GraphQLName("profileById")]
        [UseProfile]
        public async Task<IQueryable<Profile>> GetProfile([Service] IProfileService profileService,
            [Service] IAuthorizationService authorizationService,
            [Profile] Profile profile,
            int id)
        {
            await authorizationService.Authorize(
                options => {
                    options.UseProfile(profile.Id);
                    options.UseOrganization();
                }, verifier => verifier.Assert(KeycloakPermissions.ADMIN) || (
                    verifier.RequireOrganizationCorrespondence<Profile>(id) &&
                    verifier.Assert(OrganizationPermissions.VIEW_PRIVATE_INFORMATION)
                )
            );

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
