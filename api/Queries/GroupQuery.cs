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
        public IQueryable<Group> GetGroups([Service] IGroupService groupService, 
            [Service] IAuthorizationService authorizationService)
        {
            authorizationService.Authorize(
                options => {},
                verifier => verifier.Assert(KeycloakPermissions.ADMIN)
            );

            return groupService.GetAll();
        }

        [Authorize]
        [GraphQLName("groupById")]
        [UseProjection]
        [UseProfile]
        public IQueryable<Group> GetGroup([Service] IGroupService groupService,
            [Service] IAuthorizationService authorizationService, 
            [Profile] Profile profile,
            int id)
        {
            authorizationService.Authorize(
                options => {
                    options.UseProfile(profile.Id);
                    options.UseGroup(id);
                    options.UseOrganization();
                },
                verifier => verifier.Assert(assert => 
                        assert(OrganizationPermissions.VIEW_PRIVATE_INFORMATION) || 
                        assert(GroupPermissions.VIEW_PRIVATE_INFORMATION) || 
                        assert(KeycloakPermissions.ADMIN)
                    )
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
        public IQueryable<Group> GetGroups([Service] IGroupService groupService,
            [Service] IAuthorizationService profileAuthorizationService,
            [Profile] Profile profile)
        {
            profileAuthorizationService.Authorize(
                options => {
                    options.UseProfile(profile.Id);
                    options.UseOrganization();
                },
                verifier => verifier.Assert(OrganizationPermissions.VIEW_PRIVATE_INFORMATION)
            );
            
            return groupService.GetByProfileOrganization(profile.Id);
        }
    }
}
