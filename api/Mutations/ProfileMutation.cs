using AppAny.HotChocolate.FluentValidation;
using api.DTOs.Profile;
using api.Middlewares.UseProfile;
using api.Models;
using api.Services;
using api.Validators.Profile;
using HotChocolate.Authorization;
using ProfileAuthorization;
using ProfileAuthorization.Data;

namespace api.Mutations
{
    [ExtendObjectType(typeof(Mutation))]
    public class ProfileMutation
    {
        [Authorize]
        [GraphQLName("createProfile")]
        [UseProfile]
        public async Task<int> CreateProfile(
            [Service] IProfileService profileService,
            [Service] IAuthorizationService authorizationService,
            [Profile] Profile profile,
            [UseFluentValidation, UseValidator<CreateProfileInputValidator>] CreateProfileInput input)
        {
            await authorizationService.Authorize(
                options => {
                    options.UseProfile(profile.Id);
                    options.UseOrganization();
                },
                verifier => verifier.Assert(KeycloakPermissions.ADMIN) ||
                    verifier.Assert(OrganizationPermissions.CREATE_PROFILES)
            );

            int ProfileId = await profileService.Create(input);

            return ProfileId;
        }

        [Authorize]
        [GraphQLName("updateProfile")]
        [UseProfile]
        public async Task<bool> UpdateProfile(
            [Service] IProfileService profileService, 
            [Service] IAuthorizationService authorizationService,
            [UseFluentValidation, UseValidator<UpdateProfileInputValidator>] UpdateProfileInput input,
            [Profile] Profile profile)
        {
            await authorizationService.Authorize(
                options => {
                    options.UseProfile(profile.Id);
                },
                verifier => verifier.Assert(KeycloakPermissions.ADMIN) ||
                    verifier.RequireEntityCorrespondence<Profile>(input.Id)
            );

            await profileService.Update(input);

            return true;
        }

        [Authorize]
        [GraphQLName("deleteProfile")]
        [UseProfile]
        public async Task<bool> DeleteProfile(
            [Service] IProfileService profileService,
            [Service] IAuthorizationService authorizationService,
            [Profile] Profile profile,
            int id)
        {
            await authorizationService.Authorize(
                options => {
                    options.UseProfile(profile.Id);
                    options.UseOrganization();
                },
                verifier => verifier.Assert(KeycloakPermissions.ADMIN) || (
                    verifier.RequireOrganizationCorrespondence<Profile>(id) &&
                    verifier.Assert(OrganizationPermissions.DELETE_PROFILES)
                )
            );

            await profileService.Delete(id);

            return true;
        }
    }
}
