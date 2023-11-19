using educational_platform_api.Authorization.ProfileAuthorization;
using educational_platform_api.Exceptions.ProfileAuthorizationExceptions;
using educational_platform_api.Middlewares.UseAccount;
using educational_platform_api.Middlewares.UseProfile;
using educational_platform_api.Models;
using educational_platform_api.Services;
using HotChocolate.Authorization;

namespace educational_platform_api.Queries
{
    [ExtendObjectType(typeof(Query))]
    public class GroupQuery
    {
        [Authorize]
        [GraphQLName("groups_admin")]
        [UseOffsetPaging]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Group> GetGroups([Service] IGroupService groupService)
        {
            // TODO: Admin permission
            return groupService.GetAll();
        }

        [Authorize]
        [GraphQLName("groupById_admin")]
        [UseProjection]
        public IQueryable<Group> GetGroup([Service] IGroupService groupService, int id)
        {
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
            [Service] IProfileAuthorizationService profileAuthorizationService,
            [Profile] Profile profile)
        {
            profileAuthorizationService.Authorize(options =>
            {
                options.AddPolicy("GetMyOrganizationGroups");
                options.AddProfile(profile.Id);
                options.AddOrganization();
            });
            return groupService.GetByProfileOrganization(profile.Id);
        }

        [Authorize]
        [GraphQLName("groupById")]
        [UseProjection]
        [UseProfile]
        public IQueryable<Group> GetGroup([Service] IGroupService groupService, int id,
            [Service] IProfileAuthorizationService profileAuthorizationService,
            [Profile] Profile profile)
        {
            if(!groupService.CheckOrganizationCorrespondence(profile.Id, id))
            {
                throw new ProfileUnauthorizedException();
            }

            profileAuthorizationService.Authorize(options =>
            {
                options.AddPolicy("GetMyOrganizationGroups");
                options.AddProfile(profile.Id);
                options.AddOrganization();
            });
            return groupService.GetById(id);
        }
    }
}
