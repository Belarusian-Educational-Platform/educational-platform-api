using educational_platform_api.Models;
using educational_platform_api.Services;

namespace educational_platform_api.Queries
{
    [ExtendObjectType(typeof(Query))]
    public class OrganizationQuery
    {
        [GraphQLName("organizations")]
        [UseOffsetPaging]
        [UseFiltering]
        [UseSorting]
        public List<Organization> GetAllOrganizations([Service] IOrganizationService organizationService)
        {
            return new List<Organization>();
        }

        [GraphQLName("organizationById")]
        public Organization GetOrganization([Service] IOrganizationService organizationService, int id)
        {
            return new Organization();
        }
    }
}
