using AppAny.HotChocolate.FluentValidation;
using educational_platform_api.Authorization.ProfileAuthorization;
using educational_platform_api.DTOs.Relations;
using educational_platform_api.DTOs.Subgroup;
using educational_platform_api.Exceptions.ProfileAuthorizationExceptions;
using educational_platform_api.Middlewares.UseProfile;
using educational_platform_api.Models;
using educational_platform_api.Services;
using educational_platform_api.Validators.Relations;
using educational_platform_api.Validators.Subgroup;
using HotChocolate.Authorization;

namespace educational_platform_api.Mutations
{
    [ExtendObjectType(typeof(Mutation))]
    public class SubgroupMutation
    {
        [Authorize]
        [GraphQLName("addProfileToSubgroup")]
        [UseProfile]
        public bool AddProfileToGroup(
            [Service] ISubgroupService subgroupService,
            [Service] IProfileAuthorizationService profileAuthorizationService,
            [Profile] Profile profile,
            [UseFluentValidation, UseValidator<CreateProfileGroupRelationInputValidator>]
                CreateProfileSubgroupRelationInput input)
        {
            profileAuthorizationService.Authorize(options =>
            {
                options.AddPolicy("UpdateSubgroup");
                options.AddProfile(profile.Id);
                options.AddSubgroup(input.SubgroupId);
                options.AddOrganization();
            });
            if (!subgroupService.CheckCanAddProfileToSubgroup(input.ProfileId, input.SubgroupId))
            {
                throw new ProfileUnauthorizedException();
            }

            subgroupService.CreateProfileSubgroupRelation(input);

            return true;
        }

        [Authorize]
        [GraphQLName("deleteProfileFromSubgroup")]
        [UseProfile]
        public bool DeleteProfileFromGroup(
            [Service] ISubgroupService subgroupService,
            [Service] IProfileAuthorizationService profileAuthorizationService,
            [Profile] Profile profile,
            int profileId, int subgroupId)
        {
            profileAuthorizationService.Authorize(options =>
            {
                options.AddPolicy("UpdateSubgroup");
                options.AddProfile(profile.Id);
                options.AddSubgroup(subgroupId);
                options.AddOrganization();
            });

            subgroupService.DeleteProfileSubgroupRelation(profileId, subgroupId);

            return true;
        }

        [Authorize]
        [GraphQLName("createSubgroup")]
        public Subgroup CreateSubgroup(
            [Service] ISubgroupService subgroupService,
            [Service] IProfileAuthorizationService profileAuthorizationService,
            [Profile] Profile profile,
            [UseFluentValidation, UseValidator<CreateSubgroupInputValidator>] CreateSubgroupInput input)
        {
            profileAuthorizationService.Authorize(options =>
            {
                options.AddPolicy("CreateSubgroup");
                options.AddProfile(profile.Id);
                options.AddOrganization();
            });

            return subgroupService.CreateSubgroup(input);
        }

        [Authorize]
        [GraphQLName("updateSubgroup")]
        [UseProfile]
        public bool UpdateSubgroup(
            [Service] ISubgroupService subgroupService,
            [Service] IProfileAuthorizationService profileAuthorizationService,
            [Profile] Profile profile,
            [UseFluentValidation, UseValidator<UpdateSubgroupInputValidator>] UpdateSubgroupInput input)
        {
            profileAuthorizationService.Authorize(options =>
            {
                options.AddPolicy("UpdateSubgroup");
                options.AddProfile(profile.Id);
                options.AddSubgroup(input.Id);
                options.AddOrganization();
            });

            subgroupService.UpdateSubgroup(input);

            return true;
        }

        [Authorize]
        [GraphQLName("deleteSubgroup")]
        [UseProfile]
        public bool DeleteSubgroup(
            [Service] ISubgroupService subgroupService,
            [Service] IProfileAuthorizationService profileAuthorizationService,
            [Profile] Profile profile,
            int id)
        {
            profileAuthorizationService.Authorize(options =>
            {
                options.AddPolicy("DeleteSubgroup");
                options.AddProfile(profile.Id);
                options.AddSubgroup(id);
                options.AddOrganization();
            });

            subgroupService.DeleteSubgroup(id);

            return true;
        }
    }
}
