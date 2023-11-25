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
        public async Task<bool> UpdateProfileOrganizationRelation(
            [Service] IOrganizationService organizationService,
            [Service] IAuthorizationService authorizationService,
            [Profile] Profile profile,
            [UseFluentValidation, UseValidator<UpdateProfileOrganizationRelationInputValidator>]
                UpdateProfileOrganizationRelationInput input)
        {
            await authorizationService.Authorize(
                options => {
                    options.UseProfile(profile.Id);
                    options.UseOrganization(input.OrganizationId);
                },
                verifier => verifier.Assert(KeycloakPermissions.ADMIN) ||
                    // TODO : UPDATE ?!
                    verifier.Assert(OrganizationPermissions.UPDATE)
            );

            await organizationService.UpdateProfileOrganizationRelation(input);

            return true;
        }

        [Authorize]
        [GraphQLName("createOrganization")]
        public async Task<int> CreateOrganization(
            [Service] IOrganizationService organizationService, 
            [Service] IAuthorizationService authorizationService,
            [UseFluentValidation, UseValidator<CreateOrganizationInputValidator>] 
                CreateOrganizationInput input)
        {
            await authorizationService.Authorize(
                options => {},
                verifier => verifier.Assert(KeycloakPermissions.ADMIN)
            );

            int organizationId = await organizationService.Create(input);

            return organizationId;
        }

        [Authorize]
        [GraphQLName("updateOrganization")]
        [UseProfile]
        public async Task<bool> UpdateOrganization(
            [Service] IOrganizationService organizationService,
            [Service] IAuthorizationService authorizationService,
            [Profile] Profile profile,
            [UseFluentValidation, UseValidator<UpdateOrganizationInputValidator>] 
                UpdateOrganizationInput input)
        {
            await authorizationService.Authorize(
                options => {
                    options.UseProfile(profile.Id);
                    options.UseOrganization(input.Id);
                },
                verifier => verifier.Assert(KeycloakPermissions.ADMIN) ||
                    verifier.Assert(OrganizationPermissions.UPDATE)
            );

            await organizationService.Update(input);

            return true;
        }

        [Authorize]
        [GraphQLName("deleteOrganization")]
        public async Task<bool> DeleteOrganization(
            [Service] IOrganizationService organizationService, 
            [Service] IAuthorizationService authorizationService,
            int id)
        {
            await authorizationService.Authorize(
                options => {},
                verifier => verifier.Assert(KeycloakPermissions.ADMIN)
            );
            await organizationService.Delete(id);

            return true;
        }
    }
}
