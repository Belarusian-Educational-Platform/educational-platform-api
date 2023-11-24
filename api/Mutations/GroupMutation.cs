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
using ProfileAuthorization.Data;
using Microsoft.Extensions.Options;

namespace api.Mutations
{
    [ExtendObjectType(typeof(Mutation))]
    public class GroupMutation
    {
        [Authorize]
        [GraphQLName("updateProfileGroupRelation")]
        [UseProfile]
        public bool UpdateProfileGroupRelation(
            [Service] IGroupService groupService,
            [Service] IAuthorizationService authorizationService,
            [Profile] Profile profile,
            [UseFluentValidation, UseValidator<UpdateProfileGroupRelationInputValidator>]
                UpdateProfileGroupRelationInput input)
        {
            authorizationService.Authorize(
                options => {
                    options.UseProfile(profile.Id);
                    options.UseGroup(input.GroupId);
                    options.UseOrganization();
                },
                // TODO : FOR WHAT WE NEED EDIT_PERMIISONS
                verifier => verifier.Assert(KeycloakPermissions.ADMIN) || 
                    verifier.Assert(OrganizationPermissions.EDIT_GROUP_PROFILES_PERMISSIONS) ||
                    verifier.Assert(GroupPermissions.EDIT_PROFILES_PERMISSIONS)
            );

            groupService.UpdateProfileGroupRelation(input);

            return true;
        }

        [Authorize]
        [GraphQLName("addProfileToGroup")]
        [UseProfile]
        public bool AddProfileToGroup(
            [Service] IGroupService groupService,
            [Service] IAuthorizationService authorizationService,
            [Profile] Profile profile,
            [UseFluentValidation, UseValidator<CreateProfileGroupRelationInputValidator>] 
                CreateProfileGroupRelationInput input)
        {
            authorizationService.Authorize(
                options => {
                    options.UseProfile(profile.Id);
                    options.UseGroup(input.GroupId);
                    options.UseOrganization();
                },
                verifier => verifier.Assert(KeycloakPermissions.ADMIN) || 
                    verifier.Assert(OrganizationPermissions.UPDATE_GROUPS) ||
                    verifier.Assert(GroupPermissions.UPDATE)
            );

            groupService.CreateProfileGroupRelation(input);

            return true;
        }

        [Authorize]
        [GraphQLName("deleteProfileFromGroup")]
        [UseProfile]
        public bool DeleteProfileFromGroup(
            [Service] IGroupService groupService,
            [Service] IAuthorizationService authorizationService,
            [Profile] Profile profile,
            int profileId, int groupId)
        {
            authorizationService.Authorize(
                options => {
                    options.UseProfile(profile.Id);
                    options.UseGroup(groupId);
                    options.UseOrganization();
                },
                verifier => verifier.Assert(KeycloakPermissions.ADMIN) || 
                    verifier.Assert(OrganizationPermissions.UPDATE_GROUPS) ||
                    verifier.Assert(GroupPermissions.UPDATE)
            );

            groupService.DeleteProfileGroupRelation(profileId, groupId);

            return true;
        }

        [Authorize]
        [GraphQLName("createGroup")]
        [UseProfile]
        public int CreateGroup(
            [Service] IGroupService groupService,
            [Service] IAuthorizationService authorizationService,
            [Profile] Profile profile,
            [UseFluentValidation, UseValidator<CreateGroupInputValidator>] CreateGroupInput input)
        {
            authorizationService.Authorize(
                options => {
                    options.UseProfile(profile.Id);
                    options.UseOrganization();
                },
                verifier => verifier.Assert(KeycloakPermissions.ADMIN) || 
                    verifier.Assert(OrganizationPermissions.CREATE_GROUPS)
            );

            int groupId = groupService.Create(input);

            return groupId;
        }

        [Authorize]
        [GraphQLName("updateGroup")]
        [UseProfile]
        public bool UpdateGroup(
            [Service] IGroupService groupService,
            [Service] IAuthorizationService authorizationService,
            [Profile] Profile profile,
            [UseFluentValidation, UseValidator<UpdateGroupInputValidator>] UpdateGroupInput input)
        {
            authorizationService.Authorize(
                options => {
                    options.UseProfile(profile.Id);
                    options.UseGroup(input.Id);
                    options.UseOrganization();
                },
                verifier => verifier.Assert(KeycloakPermissions.ADMIN) || 
                    verifier.Assert(OrganizationPermissions.UPDATE_GROUPS) ||
                    verifier.Assert(GroupPermissions.UPDATE)
            );

            groupService.Update(input);

            return true;
        }

        [Authorize]
        [GraphQLName("deleteGroup")]
        [UseProfile]
        public bool DeleteGroup(
            [Service] IGroupService groupService,
            [Service] IAuthorizationService authorizationService,
            [Profile] Profile profile,
            int id)
        {
            authorizationService.Authorize(
                options => {
                    options.UseProfile(profile.Id);
                    options.UseGroup(id);
                    options.UseOrganization();
                },
                verifier => verifier.Assert(KeycloakPermissions.ADMIN) || 
                    verifier.Assert(OrganizationPermissions.DELETE_GROUPS) ||
                    verifier.Assert(GroupPermissions.DELETE)
            );

            groupService.Delete(id);

            return true;
        }
    }
}
