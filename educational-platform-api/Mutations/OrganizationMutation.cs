using AppAny.HotChocolate.FluentValidation;
using educational_platform_api.Authorization.ProfileAuthorization;
using educational_platform_api.DTOs.Organization;
using educational_platform_api.Exceptions.ProfileAuthorizationExceptions;
using educational_platform_api.Middlewares.UseProfile;
using educational_platform_api.Models;
using educational_platform_api.Services;
using educational_platform_api.Validators.Organization;
using HotChocolate.Authorization;

namespace educational_platform_api.Mutations
{
    [ExtendObjectType(typeof(Mutation))]
    public class OrganizationMutation
    {
        [Authorize(Roles = new[] { "Admin" })]
        [GraphQLName("createOrganization")]
        [UseProjection]
        public int CreateOrganization(
            [Service] IOrganizationService organizationService, 
            [UseFluentValidation, UseValidator<CreateOrganizationInputValidator>] 
                CreateOrganizationInput organizationInput)
        {
            int OrganizationId = organizationService.Create(organizationInput);

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
                UpdateOrganizationInput organizationInput)
        {
            if (!organizationService.CheckProfileInOrganization(profile.Id, organizationInput.Id))
            {
                throw new ProfileUnauthorizedException();
            }
            profileAuthorizationService.Authorize(options =>
            {
                options.AddPolicy("Update");
                options.AddProfile(profile.Id);
                options.AddOrganization();
            });

            organizationService.Update(organizationInput);

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
