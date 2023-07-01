using educational_platform_api.Models;
using educational_platform_api.Services;

namespace educational_platform_api.Mutations
{
    [ExtendObjectType(typeof(Mutation))]
    public class OrganizationMutation
    {
        [GraphQLName("createOrganization")]
        public Organization CreateOrganization([Service] IOrganizationService organizationService, 
            Organization organization)
        {
            return organization;
        }

        [GraphQLName("updateOrganization")]
        public Organization UpdateOrganization([Service] IOrganizationService organizationService, 
            Organization organization)
        {
            return organization;
        }

        [GraphQLName("deleteOrganization")]
        public bool DeleteOrganization([Service] IOrganizationService organizationService, int id)
        {
            return true;
        }
    }
}
