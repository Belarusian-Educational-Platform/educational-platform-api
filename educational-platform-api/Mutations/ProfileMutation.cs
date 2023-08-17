using AppAny.HotChocolate.FluentValidation;
using educational_platform_api.Authorization.ProfileAuthorization;
using educational_platform_api.DTOs.Profile;
using educational_platform_api.Exceptions.ProfileAuthorizationExceptions;
using educational_platform_api.Middlewares.UseProfile;
using educational_platform_api.Models;
using educational_platform_api.Services;
using educational_platform_api.Validators.Profile;
using HotChocolate.Authorization;

namespace educational_platform_api.Mutations
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
            [UseFluentValidation, UseValidator<CreateProfileInputValidator>] CreateProfileInput profileInput)
        {
            profileAuthorizationService.Authorize(options =>
            {
                options.AddPolicy("CreateProfile");
                options.AddProfile(profile.Id);
                options.AddOrganization();
            });

            int ProfileId = profileService.Create(profileInput);

            return ProfileId;
        }

        [Authorize]
        [GraphQLName("updateProfile")]
        [UseProfile]
        public bool UpdateProfile([Service] IProfileService profileService, 
            [UseFluentValidation, UseValidator<UpdateProfileInputValidator>] UpdateProfileInput profileInput,
            [Profile] Profile profile)
        {
            if (profile.Id != profileInput.Id)
            {
                throw new ProfileUnauthorizedException();
            }

            profileService.Update(profileInput);

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
