using educational_platform_api.Authorization.ProfileAuthorization;
using educational_platform_api.DTOs.Group;
using educational_platform_api.Middlewares.UseProfile;
using educational_platform_api.Models;
using educational_platform_api.Services;
using HotChocolate.Authorization;

namespace educational_platform_api.Mutations
{
    [ExtendObjectType(typeof(Mutation))]
    public class GroupMutation
    {
        [Authorize]
        [GraphQLName("createGroup")]
        [UseProfile]
        public Group CreateGroup(
            [Service] IGroupService groupService,
            [Service] IProfileAuthorizationService profileAuthorizationService,
            [Profile] Profile profile,
            CreateGroupInput input)
        {
            profileAuthorizationService.Authorize(options =>
            {
                options.AddPolicy("CreateGroup");
                options.AddProfile(profile.Id);
                options.AddOrganization();
            });

            Group groupEntity = groupService.CreateGroup(input);

            return groupEntity;
        }

        [Authorize]
        [GraphQLName("updateGroup")]
        [UseProfile]
        public bool UpdateGroup(
            [Service] IGroupService groupService,
            [Service] IProfileAuthorizationService profileAuthorizationService,
            [Profile] Profile profile,
            UpdateGroupInput input)
        {
            profileAuthorizationService.Authorize(options =>
            {
                options.AddPolicy("UpdateGroup");
                options.AddProfile(profile.Id);
                options.AddGroup(input.Id);
                options.AddOrganization();
            });

            groupService.UpdateGroup(input);

            return true;
        }

        [Authorize]
        [GraphQLName("deleteGroup")]
        [UseProfile]
        public bool DeleteGroup(
            [Service] IGroupService groupService,
            [Service] IProfileAuthorizationService profileAuthorizationService,
            [Profile] Profile profile,
            int id)
        {
            profileAuthorizationService.Authorize(options =>
            {
                options.AddPolicy("DeleteGroup");
                options.AddProfile(profile.Id);
                options.AddGroup(id);
                options.AddOrganization();
            });

            groupService.DeleteGroup(id);

            return true;
        }
    }
}
