using AppAny.HotChocolate.FluentValidation;
using educational_platform_api.DTOs;
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
        public Profile CreateProfile([Service] IProfileService profileService, 
             [UseFluentValidation, UseValidator<CreateProfileInputValidator>] CreateProfileInput profileInput)
        {
            Profile profile = profileService.CreateProfile(profileInput);

            return profile;
        }

        [Authorize]
        [GraphQLName("updateProfile")]
        public Profile UpdateProfile([Service] IProfileService profileService, 
            [UseFluentValidation, UseValidator<UpdateProfileInputValidator>] UpdateProfileInput profileInput)
        {
            Profile profile = profileService.UpdateProfile(profileInput);

            return profile;
        }

        [Authorize]
        [GraphQLName("deleteProfile")]
        public bool DeleteProfile([Service] IProfileService profileService, int id)
        {
            return profileService.DeleteProfile(id);
        }
    }
}
