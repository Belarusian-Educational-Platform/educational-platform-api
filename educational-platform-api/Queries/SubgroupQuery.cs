using educational_platform_api.Authorization.ProfileAuthorization;
using educational_platform_api.Middlewares.UseProfile;
using educational_platform_api.Models;
using educational_platform_api.Services;
using HotChocolate.Authorization;

namespace educational_platform_api.Queries
{
    [ExtendObjectType(typeof(Query))]
    public class SubgroupQuery
    {
        [Authorize]
        [GraphQLName("subgroups")]
        [UseOffsetPaging]
        [UseFiltering]
        [UseSorting]
        public IEnumerable<Subgroup> GetSubgroups([Service] ISubgroupService subgroupService)
        {
            return subgroupService.GetAllSubgroups();
        }

        [Authorize]
        [GraphQLName("subgroupById")]
        public Subgroup GetSubgroup([Service] ISubgroupService subgroupService, int id)
        {
            return subgroupService.GetSubgroupById(id);
        }

        [Authorize]
        [GraphQLName("mySubgroups")]
        [UseProfile]
        public IEnumerable<Subgroup> GetMySubgroups(
            [Service] ISubgroupService subgroupService, 
            [Profile] Profile profile)
        {
            return subgroupService.GetProfileSubgroups(profile.Id);
        }

        [Authorize]
        [GraphQLName("groupSubgroups")]
        [UseProfile]
        public IEnumerable<Subgroup> GetGroupSubgroups(
            [Service] ISubgroupService subgroupService, 
            [Service] IProfileAuthorizationService profileAuthorizationService, 
            [Profile] Profile profile,
            int groupId)
        {
            profileAuthorizationService.Authorize(options =>
            {
                options.AddPolicy("GetGroupSubgroups");
                options.AddProfile(profile.Id);
                options.AddGroup(groupId);
                options.AddOrganization();
            });

            // TODO CHECK GROUP ORGANIZATION IS IN THE PROFILE ORGANIZATION
            return subgroupService.GetGroupSubgroups(groupId);
        }
    }
}
