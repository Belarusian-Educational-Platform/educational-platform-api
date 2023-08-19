using AppAny.HotChocolate.FluentValidation;
using educational_platform_api.Authorization.ProfileAuthorization;
using educational_platform_api.DTOs.Organization;
using educational_platform_api.DTOs.Relations;
using educational_platform_api.Exceptions.ProfileAuthorizationExceptions;
using educational_platform_api.Middlewares.UseProfile;
using educational_platform_api.Models;
using educational_platform_api.Services;
using educational_platform_api.Validators.Organization;
using educational_platform_api.Validators.Relations;
using HotChocolate.Authorization;

namespace educational_platform_api.Mutations
{
    [ExtendObjectType(typeof(Mutation))]
    public class OrganizationMutation
    {
        [Authorize]
        [GraphQLName("updateProfileOrganizationRelation")]
        [UseProfile]
        public bool UpdateProfileOrganizationRelation(
            [Service] IOrganizationService organizationService,
            [Service] IProfileAuthorizationService profileAuthorizationService,
            [Profile] Profile profile,
            [UseFluentValidation, UseValidator<UpdateProfileOrganizationRelationInputValidator>]
                UpdateProfileOrganizationRelationInput input)
        {
            if (!organizationService.CheckProfileInOrganization(profile.Id, input.OrganizationId))
            {
                throw new ProfileUnauthorizedException();
            }
            profileAuthorizationService.Authorize(options =>
            {
                options.AddPolicy("UpdateOrganization");
                options.AddProfile(profile.Id);
                options.AddOrganization();
            });

            organizationService.UpdateProfileOrganizationRelation(input);

            return true;
        }

        [Authorize(Roles = new[] { "Admin" })]
        [GraphQLName("createOrganization")]
        public int CreateOrganization(
            [Service] IOrganizationService organizationService, 
            [UseFluentValidation, UseValidator<CreateOrganizationInputValidator>] 
                CreateOrganizationInput input)
        {
            int OrganizationId = organizationService.Create(input);

            return OrganizationId;
        }

        [Authorize]
        [GraphQLName("updateOrganization")]
        [UseProfile]
        public bool UpdateOrganization(
            [Service] IOrganizationService organizationService,
            [Service] IProfileAuthorizationService profileAuthorizationService,
            [Profile] Profile profile,
            [UseFluentValidation, UseValidator<UpdateOrganizationInputValidator>] 
                UpdateOrganizationInput input)
        {
            if (!organizationService.CheckProfileInOrganization(profile.Id, input.Id))
            {
                throw new ProfileUnauthorizedException();
            }
            profileAuthorizationService.Authorize(options =>
            {
                options.AddPolicy("UpdateOrganization");
                options.AddProfile(profile.Id);
                options.AddOrganization();
            });

            organizationService.Update(input);

            return true;
        }

        [Authorize(Roles = new[] { "Admin" })]
        [GraphQLName("deleteOrganization")]
        public bool DeleteOrganization([Service] IOrganizationService organizationService, int id)
        {
            organizationService.Delete(id);

            return true;
        }
    }
}
