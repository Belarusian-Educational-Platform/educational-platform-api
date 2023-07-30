using educational_platform_api.DTOs;
using educational_platform_api.Models;
using educational_platform_api.Services;
using HotChocolate.Authorization;

namespace educational_platform_api.Mutations
{
    [ExtendObjectType(typeof(Mutation))]
    public class OrganizationMutation
    {
        [Authorize]
        [GraphQLName("createOrganization")]
        public Organization CreateOrganization(
            [Service] IOrganizationService organizationService, 
            CreateOrganizationInput organizationInput)
        {
            Organization organizationEntity = organizationService.CreateOrganization(organizationInput);

            return organizationEntity;
        }

        [Authorize]
        [GraphQLName("updateOrganization")]
        public bool UpdateOrganization([Service] IOrganizationService organizationService,
            UpdateOrganizationInput organizationInput)
        {
            organizationService.UpdateOrganization(organizationInput);

            return true;
        }

        [Authorize]
        [GraphQLName("deleteOrganization")]
        public bool DeleteOrganization([Service] IOrganizationService organizationService, int id)
        {
            organizationService.DeleteOrganization(id);

            return true;
        }
    }
}
