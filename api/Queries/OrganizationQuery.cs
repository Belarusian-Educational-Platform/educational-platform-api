using api.Middlewares.UseProfile;
using api.Models;
using api.Services;
using HotChocolate.Authorization;
using ProfileAuthorization;
using ProfileAuthorization.Data;

namespace api.Queries
{
    [ExtendObjectType(typeof(Query))]
    public class OrganizationQuery
    {
        [Authorize]
        [GraphQLName("organizations")]
        [UseOffsetPaging]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public async Task<IQueryable<Organization>> GetOrganizations(
            [Service] IOrganizationService organizationService,
            [Service] IAuthorizationService authorizationService)
        {
            await authorizationService.Authorize(
                options => {},
                verifier => verifier.Assert(KeycloakPermissions.ADMIN)
            );
            
            return organizationService.GetAll();
        }

        [Authorize]
        [GraphQLName("organizationById")]
        [UseProjection]
        [UseProfile]
        public async Task<IQueryable<Organization>> GetOrganization(
            [Service] IOrganizationService organizationService,
            [Service] IAuthorizationService authorizationService,
            [Profile] Profile profile,
            int id)
        {
            await authorizationService.Authorize(
                options => {
                    options.UseProfile(profile.Id);
                    options.UseOrganization(id);
                },
                verifier => verifier.Assert(KeycloakPermissions.ADMIN) || 
                    verifier.Assert(OrganizationPermissions.VIEW_PRIVATE_INFORMATION)
            );

            return organizationService.GetById(id);
        }
    }
}
