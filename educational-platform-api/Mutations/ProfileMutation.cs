using educational_platform_api.Models;
using educational_platform_api.Services;

namespace educational_platform_api.Mutations
{
    [ExtendObjectType(typeof(Mutation))]
    public class ProfileMutation
    {
        [GraphQLName("createProfile")]
        public Profile CreateProfile([Service] IProfileService profileService, Profile profile)
        {
            return profile;
        }

        [GraphQLName("updateProfile")]
        public Profile UpdateProfile([Service] IProfileService profileService, Profile profile)
        {
            return profile;
        }

        [GraphQLName("deleteProfile")]
        public bool DeleteProfile([Service] IProfileService profileService, int id)
        {
            return true;
        }
    }
}
