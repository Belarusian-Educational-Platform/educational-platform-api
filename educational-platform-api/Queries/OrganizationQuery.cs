using educational_platform_api.Authorization.ProfileAuthorization;
using educational_platform_api.Exceptions.ProfileAuthorizationExceptions;
using educational_platform_api.Middlewares.UseProfile;
using educational_platform_api.Models;
using educational_platform_api.Services;
using HotChocolate.Authorization;

namespace educational_platform_api.Queries
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
            [Service] IProfileAuthorizationService profileAuthorizationService,
            [Profile] Profile profile)
        {
            if (!organizationService.CheckProfileInOrganization(profile.Id, id))
            {
                throw new ProfileUnauthorizedException();
            }
            profileAuthorizationService.Authorize(options =>
            {
                options.AddPolicy("GetMyOrganization");
                options.AddProfile(profile.Id);
                options.AddOrganization();
            });
            return organizationService.GetById(id);
        }
    }
}
