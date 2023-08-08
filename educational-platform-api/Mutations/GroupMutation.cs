using AppAny.HotChocolate.FluentValidation;
using educational_platform_api.Authorization.ProfileAuthorization;
using educational_platform_api.DTOs.Group;
using educational_platform_api.DTOs.Relations;
using educational_platform_api.Exceptions.ProfileAuthorizationExceptions;
using educational_platform_api.Middlewares.UseProfile;
using educational_platform_api.Models;
using educational_platform_api.Services;
using educational_platform_api.Validators.Group;
using educational_platform_api.Validators.Relations;
using HotChocolate.Authorization;

namespace educational_platform_api.Mutations
{
    [ExtendObjectType(typeof(Mutation))]
    public class GroupMutation
    {
        [Authorize]
        [GraphQLName("addProfileToGroup")]
        [UseProfile]
        public bool AddProfileToGroup(
            [Service] IGroupService groupService,
            [Service] IProfileAuthorizationService profileAuthorizationService,
            [Profile] Profile profile,
            [UseFluentValidation, UseValidator<CreateProfileGroupRelationInputValidator>] 
                CreateProfileGroupRelationInput input)
        {
            profileAuthorizationService.Authorize(options =>
            {
                options.AddPolicy("UpdateGroup");
                options.AddProfile(profile.Id);
                options.AddGroup(input.GroupId);
                options.AddOrganization();
            });
            if (!groupService.CheckCanAddProfileToGroup(input.ProfileId, input.GroupId))
            {
                throw new ProfileUnauthorizedException();
            }

            groupService.CreateProfileGroupRelation(input);

            return true;
        }

        [Authorize]
        [GraphQLName("deleteProfileFromGroup")]
        [UseProfile]
        public bool DeleteProfileFromGroup(
            [Service] IGroupService groupService,
            [Service] IProfileAuthorizationService profileAuthorizationService,
            [Profile] Profile profile,
            int profileId, int groupId)
        {
            profileAuthorizationService.Authorize(options =>
            {
                options.AddPolicy("UpdateGroup");
                options.AddProfile(profile.Id);
                options.AddGroup(groupId);
                options.AddOrganization();
            });

            groupService.DeleteProfileGroupRelation(profileId, groupId);

            return true;
        }

        [Authorize]
        [GraphQLName("createGroup")]
        [UseProfile]
        public Group CreateGroup(
            [Service] IGroupService groupService,
            [Service] IProfileAuthorizationService profileAuthorizationService,
            [Profile] Profile profile,
            [UseFluentValidation, UseValidator<CreateGroupInputValidator>]  CreateGroupInput input)
        {
            profileAuthorizationService.Authorize(options =>
            {
                options.AddPolicy("CreateGroup");
                options.AddProfile(profile.Id);
                options.AddOrganization();
            });

            var groupEntity = groupService.Create(input);

            return groupEntity;
        }

        [Authorize]
        [GraphQLName("updateGroup")]
        [UseProfile]
        public bool UpdateGroup(
            [Service] IGroupService groupService,
            [Service] IProfileAuthorizationService profileAuthorizationService,
            [Profile] Profile profile,
            [UseFluentValidation, UseValidator<UpdateGroupInputValidator>] UpdateGroupInput input)
        {
            profileAuthorizationService.Authorize(options =>
            {
                options.AddPolicy("UpdateGroup");
                options.AddProfile(profile.Id);
                options.AddGroup(input.Id);
                options.AddOrganization();
            });

            groupService.Update(input);

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

            groupService.Delete(id);

            return true;
        }
    }
}
