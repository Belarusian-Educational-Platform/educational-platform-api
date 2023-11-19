using AppAny.HotChocolate.FluentValidation;
using api.Authorization.ProfileAuthorization;
using api.DTOs.Profile;
using api.Exceptions.ProfileAuthorizationExceptions;
using api.Middlewares.UseProfile;
using api.Models;
using api.Services;
using api.Validators.Profile;
using HotChocolate.Authorization;

namespace api.Mutations
{
    [ExtendObjectType(typeof(Mutation))]
    public class ProfileMutation
    {
        [Authorize]
        [GraphQLName("createProfile")]
        [UseProfile]
        public int CreateProfile(
            [Service] IProfileService profileService,
            [Service] IProfileAuthorizationService profileAuthorizationService,
            [Profile] Profile profile,
            [UseFluentValidation, UseValidator<CreateProfileInputValidator>] CreateProfileInput input)
        {
            profileAuthorizationService.Authorize(options =>
            {
                options.AddPolicy("CreateProfile");
                options.AddProfile(profile.Id);
                options.AddOrganization();
            });

            int ProfileId = profileService.Create(input);

            return ProfileId;
        }

        [Authorize]
        [GraphQLName("updateProfile")]
        [UseProfile]
        public bool UpdateProfile([Service] IProfileService profileService, 
            [UseFluentValidation, UseValidator<UpdateProfileInputValidator>] UpdateProfileInput input,
            [Profile] Profile profile)
        {
            if (profile.Id != input.Id)
            {
                throw new ProfileUnauthorizedException();
            }

            profileService.Update(input);

            return true;
        }

        [Authorize]
        [GraphQLName("deleteProfile")]
        [UseProfile]
        public bool DeleteProfile(
            [Service] IProfileService profileService,
            [Service] IProfileAuthorizationService profileAuthorizationService,
            [Profile] Profile profile,
            int id)
        {
            profileAuthorizationService.Authorize(options =>
            {
                options.AddPolicy("DeleteProfile");
                options.AddProfile(profile.Id);
                options.AddOrganization();
            });

            profileService.Delete(id);

            return true;
        }
    }
}
