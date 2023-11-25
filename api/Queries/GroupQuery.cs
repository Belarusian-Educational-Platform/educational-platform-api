using api.Middlewares.UseProfile;
using api.Models;
using api.Services;
using HotChocolate.Authorization;
using ProfileAuthorization;
using ProfileAuthorization.Data;
using ProfileAuthorization.Exceptions;

namespace api.Queries
{
    [ExtendObjectType(typeof(Query))]
    public class GroupQuery
    {
        [Authorize]
        [GraphQLName("groups")]
        [UseOffsetPaging]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public async Task<IQueryable<Group>> GetGroups([Service] IGroupService groupService,
            [Service] IAuthorizationService authorizationService)
        {
            await authorizationService.Authorize(
                options => { },
                verifier => verifier.Assert(KeycloakPermissions.ADMIN)
            );

            return groupService.GetAll();
        }

        [Authorize]
        [GraphQLName("groupById")]
        [UseProjection]
        [UseProfile]
        public async Task<IQueryable<Group>> GetGroup([Service] IGroupService groupService,
            [Service] IAuthorizationService authorizationService, 
            [Profile] Profile profile,
            int id)
        {
            await authorizationService.Authorize(
                options => {
                    options.UseProfile(profile.Id);
                    options.UseGroup(id);
                    options.UseOrganization();
                },
                verifier => verifier.Assert(KeycloakPermissions.ADMIN) || 
                    verifier.Assert(OrganizationPermissions.VIEW_PRIVATE_INFORMATION) || 
                    verifier.Assert(GroupPermissions.VIEW_PRIVATE_INFORMATION) 
            );

            return groupService.GetById(id);
        }

        [Authorize]
        [GraphQLName("myOrganizationGroups")]
        [UseProfile]
        [UseOffsetPaging]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public async Task<IQueryable<Group>> GetGroups([Service] IGroupService groupService,
            [Service] IAuthorizationService authorizationService,
            [Profile] Profile profile)
        {
            await authorizationService.Authorize(
                options => {
                    options.UseProfile(profile.Id);
                    options.UseOrganization();
                },
                verifier => verifier.Assert(OrganizationPermissions.VIEW_PRIVATE_INFORMATION)
            );
            
            return await groupService.GetByProfileOrganization(profile.Id);
        }
    }
}
