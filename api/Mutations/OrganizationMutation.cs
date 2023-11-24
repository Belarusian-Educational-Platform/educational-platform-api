using AppAny.HotChocolate.FluentValidation;
using api.DTOs.Organization;
using api.DTOs.Relations;
using api.Middlewares.UseProfile;
using api.Models;
using api.Services;
using api.Validators.Organization;
using api.Validators.Relations;
using HotChocolate.Authorization;
using ProfileAuthorization;
using ProfileAuthorization.Exceptions;
using ProfileAuthorization.Data;

namespace api.Mutations
{
    [ExtendObjectType(typeof(Mutation))]
    public class OrganizationMutation
    {
        [Authorize]
        [GraphQLName("updateProfileOrganizationRelation")]
        [UseProfile]
        public bool UpdateProfileOrganizationRelation(
            [Service] IOrganizationService organizationService,
            [Service] IAuthorizationService authorizationService,
            [Profile] Profile profile,
            [UseFluentValidation, UseValidator<UpdateProfileOrganizationRelationInputValidator>]
                UpdateProfileOrganizationRelationInput input)
        {
            authorizationService.Authorize(
                options => {
                    options.UseProfile(profile.Id);
                    options.UseOrganization(input.OrganizationId);
                },
                verifier => verifier.Assert(KeycloakPermissions.ADMIN) ||
                    // TODO : UPDATE ?!
                    verifier.Assert(OrganizationPermissions.UPDATE)
            );

            organizationService.UpdateProfileOrganizationRelation(input);

            return true;
        }

        [Authorize]
        [GraphQLName("createOrganization")]
        public int CreateOrganization(
            [Service] IOrganizationService organizationService, 
            [Service] IAuthorizationService authorizationService,
            [UseFluentValidation, UseValidator<CreateOrganizationInputValidator>] 
                CreateOrganizationInput input)
        {
            authorizationService.Authorize(
                options => {},
                verifier => verifier.Assert(KeycloakPermissions.ADMIN)
            );

            int organizationId = organizationService.Create(input);

            return organizationId;
        }

        [Authorize]
        [GraphQLName("updateOrganization")]
        [UseProfile]
        public bool UpdateOrganization(
            [Service] IOrganizationService organizationService,
            [Service] IAuthorizationService authorizationService,
            [Profile] Profile profile,
            [UseFluentValidation, UseValidator<UpdateOrganizationInputValidator>] 
                UpdateOrganizationInput input)
        {
            authorizationService.Authorize(
                options => {
                    options.UseProfile(profile.Id);
                    options.UseOrganization(input.Id);
                },
                verifier => verifier.Assert(KeycloakPermissions.ADMIN) ||
                    verifier.Assert(OrganizationPermissions.UPDATE)
            );

            organizationService.Update(input);

            return true;
        }

        [Authorize]
        [GraphQLName("deleteOrganization")]
        public bool DeleteOrganization(
            [Service] IOrganizationService organizationService, 
            [Service] IAuthorizationService authorizationService,
            int id)
        {
            authorizationService.Authorize(
                options => {},
                verifier => verifier.Assert(KeycloakPermissions.ADMIN)
            );
            organizationService.Delete(id);

            return true;
        }
    }
}
