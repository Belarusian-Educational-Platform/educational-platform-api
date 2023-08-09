﻿using educational_platform_api.Middlewares.UseProfile;
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
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Organization> GetOrganizations([Service] IOrganizationService organizationService)
        {
            return organizationService.GetAllOrganizations();
        }

        [Authorize]
        [GraphQLName("organizationById")]
        [UseProjection]
        public IQueryable<Organization> GetOrganization([Service] IOrganizationService organizationService, int id)
        {
            return organizationService.GetOrganizationById(id);
        }
    }
}
