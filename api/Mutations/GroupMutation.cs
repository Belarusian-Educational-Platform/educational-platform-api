using AppAny.HotChocolate.FluentValidation;
using api.DTOs.Group;
using api.DTOs.Relations;
using api.Middlewares.UseProfile;
using api.Models;
using api.Services;
using api.Validators.Group;
using api.Validators.Relations;
using HotChocolate.Authorization;
using ProfileAuthorization.Exceptions;
using ProfileAuthorization;

namespace api.Mutations
{
    [ExtendObjectType(typeof(Mutation))]
    public class GroupMutation
    {
        // [Authorize]
        // [GraphQLName("updateProfileGroupRelation")]
        // [UseProfile]
        // public bool UpdateProfileGroupRelation(
        //     [Service] IGroupService groupService,
        //     [Service] IAuthorizationService profileAuthorizationService,
        //     [Profile] Profile profile,
        //     [UseFluentValidation, UseValidator<UpdateProfileGroupRelationInputValidator>]
        //         UpdateProfileGroupRelationInput input)
        // {
        //     profileAuthorizationService.Authorize(options =>
        //     {
        //         options.UsePolicy("UpdateProfileGroupRelation");
        //         options.UseProfile(profile.Id);
        //         options.UseGroup(input.GroupId);
        //         options.UseOrganization();
        //     });

        //     if (!groupService.CheckOrganizationCorrespondence(input.ProfileId, input.GroupId))
        //     {
        //         throw new ProfileUnauthorizedException();
        //     }

        //     groupService.UpdateProfileGroupRelation(input);

        //     return true;
        // }

        // [Authorize]
        // [GraphQLName("addProfileToGroup")]
        // [UseProfile]
        // public bool AddProfileToGroup(
        //     [Service] IGroupService groupService,
        //     [Service] IAuthorizationService profileAuthorizationService,
        //     [Profile] Profile profile,
        //     [UseFluentValidation, UseValidator<CreateProfileGroupRelationInputValidator>] 
        //         CreateProfileGroupRelationInput input)
        // {
        //     profileAuthorizationService.Authorize(options =>
        //     {
        //         options.UsePolicy("UpdateGroup");
        //         options.UseProfile(profile.Id);
        //         options.UseGroup(input.GroupId);
        //         options.UseOrganization();
        //     });
        //     if (!groupService.CheckOrganizationCorrespondence(input.ProfileId, input.GroupId))
        //     {
        //         throw new ProfileUnauthorizedException();
        //     }

        //     groupService.CreateProfileGroupRelation(input);

        //     return true;
        // }

        // [Authorize]
        // [GraphQLName("deleteProfileFromGroup")]
        // [UseProfile]
        // public bool DeleteProfileFromGroup(
        //     [Service] IGroupService groupService,
        //     [Service] IAuthorizationService profileAuthorizationService,
        //     [Profile] Profile profile,
        //     int profileId, int groupId)
        // {
        //     profileAuthorizationService.Authorize(options =>
        //     {
        //         options.UsePolicy("UpdateGroup");
        //         options.UseProfile(profile.Id);
        //         options.UseGroup(groupId);
        //         options.UseOrganization();
        //     });

        //     groupService.DeleteProfileGroupRelation(profileId, groupId);

        //     return true;
        // }

        // [Authorize]
        // [GraphQLName("createGroup")]
        // [UseProfile]
        // public int CreateGroup(
        //     [Service] IGroupService groupService,
        //     [Service] IAuthorizationService profileAuthorizationService,
        //     [Profile] Profile profile,
        //     [UseFluentValidation, UseValidator<CreateGroupInputValidator>] CreateGroupInput input)
        // {
        //     profileAuthorizationService.Authorize(options =>
        //     {
        //         options.UsePolicy("CreateGroup");
        //         options.UseProfile(profile.Id);
        //         options.UseOrganization();
        //     });

        //     int GroupId = groupService.Create(input);

        //     return GroupId;
        // }

        // [Authorize]
        // [GraphQLName("updateGroup")]
        // [UseProfile]
        // public bool UpdateGroup(
        //     [Service] IGroupService groupService,
        //     [Service] IAuthorizationService profileAuthorizationService,
        //     [Profile] Profile profile,
        //     [UseFluentValidation, UseValidator<UpdateGroupInputValidator>] UpdateGroupInput input)
        // {
        //     profileAuthorizationService.Authorize(options =>
        //     {
        //         options.UsePolicy("UpdateGroup");
        //         options.UseProfile(profile.Id);
        //         options.UseGroup(input.Id);
        //         options.UseOrganization();
        //     });

        //     groupService.Update(input);

        //     return true;
        // }

        // [Authorize]
        // [GraphQLName("deleteGroup")]
        // [UseProfile]
        // public bool DeleteGroup(
        //     [Service] IGroupService groupService,
        //     [Service] IAuthorizationService profileAuthorizationService,
        //     [Profile] Profile profile,
        //     int id)
        // {
        //     profileAuthorizationService.Authorize(options =>
        //     {
        //         options.UsePolicy("DeleteGroup");
        //         options.UseProfile(profile.Id);
        //         options.UseGroup(id);
        //         options.UseOrganization();
        //     });

        //     groupService.Delete(id);

        //     return true;
        // }
    }
}
