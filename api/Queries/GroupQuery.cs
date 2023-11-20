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
            authorizationService.Authorize(options => {
                options.UsePolicy(Policies.GET_GROUPS);
                options.UseKeycloak();
            });

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
            authorizationService.Authorize(options => {
                options.UsePolicy(Policies.GET_GROUP_BY_ID);
                options.UseProfile(profile.Id);
                options.UseGroup(id);
                options.UseOrganization();
                options.UseKeycloak();
            });

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
            profileAuthorizationService.Authorize(options =>
            {
                options.UsePolicy(Policies.GET_MY_ORGANIZATION_GROUPS);
                options.UseProfile(profile.Id);
                options.UseOrganization();
            });
            
            return groupService.GetByProfileOrganization(profile.Id);
        }
    }
}
