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
        [GraphQLName("organizations")]
        [UseOffsetPaging]
        [UseFiltering]
        [UseSorting]
        public IEnumerable<Organization> GetOrganizations([Service] IOrganizationService organizationService)
        {
            return organizationService.GetOrganizations();
        }

        [Authorize]
        [GraphQLName("organizationById")]
        public Organization GetOrganization([Service] IOrganizationService organizationService, int id)
        {
            return organizationService.GetOrganization(id);
        }

        [Authorize]
        [GraphQLName("myOrganization")]
        [UseProfile]
        public Organization GetMyOrganization(
            [Service] IOrganizationService organizationService, 
            [Profile] Profile profile)
        {
            return organizationService.GetProfileOrganization(profile.Id);
        }

        [Authorize]
        [GraphQLName("profileOrganization")]
        [UseProfile]
        public Organization GetProfileOrganization(
            [Service] IOrganizationService organizationService,
            int profileId)
        {
            return organizationService.GetProfileOrganization(profileId);
        }
    }
}
