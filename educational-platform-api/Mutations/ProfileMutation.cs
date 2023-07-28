using AppAny.HotChocolate.FluentValidation;
using educational_platform_api.Authorization.ProfileAuthorization;
using educational_platform_api.DTOs;
using educational_platform_api.Exceptions.ProfileAuthorizationExceptions;
using educational_platform_api.Middlewares.UseProfile;
using educational_platform_api.Models;
using educational_platform_api.Services;
using educational_platform_api.Validators;
using HotChocolate.Authorization;

namespace educational_platform_api.Mutations
{
    [ExtendObjectType(typeof(Mutation))]
    public class ProfileMutation
    {
        [Authorize]
        [GraphQLName("createProfile")]
        [UseProfile]
        public Profile CreateProfile(
            [Service] IProfileService profileService,
            [Service] IProfileAuthorizationService profileAuthorizationService,
            [Profile] Profile _profile_,
            [UseFluentValidation, UseValidator<CreateProfileInputValidator>] CreateProfileInput profileInput)
        {
            profileAuthorizationService.Authorize(options =>
            {
                options.AddPolicy("CreateProfile");
                options.AddProfile(_profile_.Id);
                options.AddOrganization();
            });

            Profile profile = profileService.CreateProfile(profileInput);

            return profile;
        }

        [Authorize]
        [GraphQLName("updateProfile")]
        [UseProfile]
        public bool UpdateProfile([Service] IProfileService profileService, 
            [UseFluentValidation, UseValidator<UpdateProfileInputValidator>] UpdateProfileInput profileInput,
            [Profile] Profile _profile_)
        {
            if (_profile_.Id != profileInput.Id)
            {
                throw new ProfileUnauthorizedException();
            }

            profileService.UpdateProfile(profileInput);

            return true;
        }

        [Authorize]
        [GraphQLName("deleteProfile")]
        [UseProfile]
        public bool DeleteProfile(
            [Service] IProfileService profileService,
            [Service] IProfileAuthorizationService profileAuthorizationService,
            [Profile] Profile _profile_,
            int id)
        {
            profileAuthorizationService.Authorize(options =>
            {
                options.AddPolicy("DeleteProfile");
                options.AddProfile(_profile_.Id);
                options.AddOrganization();
            });

            profileService.DeleteProfile(id);

            return true;
        }
    }
}
