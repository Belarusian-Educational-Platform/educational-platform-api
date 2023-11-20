using api.Middlewares.UseProfile;
using api.Models;
using api.Services;
using HotChocolate.Authorization;
using ProfileAuthorization;

namespace api.Queries
{
    [ExtendObjectType(typeof(Query))]
    public class OrganizationQuery
    {
        [Authorize]
        [GraphQLName("organizations_admin")]
        [UseOffsetPaging]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Organization> GetOrganizations([Service] IOrganizationService organizationService)
        {
            //TODO: Admin permission
            return organizationService.GetAll();
        }

        [Authorize]
        [GraphQLName("organizationById_admin")]
        [UseProjection]
        public IQueryable<Organization> GetOrganization([Service] IOrganizationService organizationService,
            int id)
        {
            return organizationService.GetById(id);
        }

        [Authorize]
        [GraphQLName("organizationById")]
        [UseProjection]
        [UseProfile]
        public IQueryable<Organization> GetOrganization([Service] IOrganizationService organizationService, int id,
            [Service] IAuthorizationService profileAuthorizationService,
            [Profile] Profile profile)
        {
            profileAuthorizationService.Authorize(options =>
            {
                options.UsePolicy("GetMyOrganization");
                options.UseProfile(profile.Id);
                options.UseOrganization();
            });
            return organizationService.GetById(id);
        }
    }
}
