using AppAny.HotChocolate.FluentValidation;
using educational_platform_api.Authorization.ProfileAuthorization;
using educational_platform_api.DTOs.Organization;
using educational_platform_api.Exceptions.ProfileAuthorizationExceptions;
using educational_platform_api.Middlewares.UseProfile;
using educational_platform_api.Models;
using educational_platform_api.Services;
using educational_platform_api.Validators;
using HotChocolate.Authorization;

namespace educational_platform_api.Mutations
{
    [ExtendObjectType(typeof(Mutation))]
    public class OrganizationMutation
    {
        [Authorize]
        [GraphQLName("createOrganization")]
        public Organization CreateOrganization(
            [Service] IOrganizationService organizationService, 
            [UseFluentValidation, UseValidator<CreateOrganizationInputValidator>] 
                CreateOrganizationInput organizationInput)
        {
            Organization organizationEntity = organizationService.CreateOrganization(organizationInput);

            return organizationEntity;
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
            if (!organizationService.CheckProfileInOrganization(profile.Id, organizationInput.Id)) // TODO: OK?
            {
                throw new ProfileUnauthorizedException();
            }
            profileAuthorizationService.Authorize(options =>
            {
                options.AddPolicy("UpdateOrganization");
                options.AddProfile(profile.Id);
                options.AddOrganization();
            });

            organizationService.UpdateOrganization(organizationInput);

            return true;
        }

        [Authorize]
        [GraphQLName("deleteOrganization")]
        public bool DeleteOrganization([Service] IOrganizationService organizationService, int id)
        {
            organizationService.DeleteOrganization(id);

            return true;
        }
    }
}
