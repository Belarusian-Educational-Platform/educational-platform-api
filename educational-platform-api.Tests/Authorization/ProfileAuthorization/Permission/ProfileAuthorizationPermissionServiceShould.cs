using educational_platform_api.Models;
using educational_platform_api.Repositories;
using educational_platform_api.Types.Enums;
using FluentAssertions;
using Moq;

namespace educational_platform_api.Authorization.ProfileAuthorization.Permission.Tests
{
    [TestClass()]
    public class ProfileAuthorizationPermissionServiceShould
    {
        private readonly IProfileAuthorizationPermissionService _permissionService;
        private readonly Mock<IProfileOrganizationRelationRepository> _organizationRelationRepositoryMock;
        private readonly Mock<IProfileGroupRelationRepository> _groupRelationRepositoryMock;
        private readonly Mock<IProfileSubgroupRelationRepository> _subgroupRelationRepositoryMock;

        public ProfileAuthorizationPermissionServiceShould()
        {
            _organizationRelationRepositoryMock = new Mock<IProfileOrganizationRelationRepository>();
            _groupRelationRepositoryMock = new Mock<IProfileGroupRelationRepository>();
            _subgroupRelationRepositoryMock = new Mock<IProfileSubgroupRelationRepository>();

            _permissionService = new ProfileAuthorizationPermissionService(_organizationRelationRepositoryMock.Object, 
                _groupRelationRepositoryMock.Object, 
                _subgroupRelationRepositoryMock.Object);
        }

        [TestMethod()]
        public void Get_Profile_Permissions_As_Expected()
        {
            // Arrange
            var profileOrganizationRelation = new ProfileOrganizationRelation()
            {
                ProfileId = 1, OrganizationId = 1, Permissions = "[\"view-private-information\"]"
            };
            var profileGroupRelation = new ProfileGroupRelation()
            {
                ProfileId = 1, GroupId = 1, Permissions = "[\"view-private-information\"]", ProfileRole = Role.member
            };
            var profileSubroupRelation = new ProfileSubgroupRelation()
            {
                ProfileId = 1, SubgroupId = 1, Permissions = "[\"view-private-information\"]", ProfileRole= Role.member
            };

            Action<ProfileAuthorizationVerificationOptions> configureVerificationOptions = (options) =>
            {
                options.AddProfile(1);
                options.AddGroup(1);
                options.AddSubgroup(1);
                options.AddOrganization();
            };
            var verificationOptions = new ProfileAuthorizationVerificationOptions();
            configureVerificationOptions(verificationOptions);

            _organizationRelationRepositoryMock
                .Setup(repo => repo.GetProfileRelation(It.IsAny<int>()))
                .Returns(profileOrganizationRelation);
            _groupRelationRepositoryMock
                .Setup(repo => repo.GetRelation(It.IsAny<int>(), It.IsAny<int>()))
                .Returns(profileGroupRelation);
            _subgroupRelationRepositoryMock
                .Setup(repo => repo.GetRelation(It.IsAny<int>(), It.IsAny<int>()))
                .Returns(profileSubroupRelation);

            Action<ProfileAuthorizationPermissionSet> configurePermissionSet = (permissionSet) =>
            {
                permissionSet.AddPermissions(ProfileAuthorizationPermissionLevel.PROFILE_ORGANIZATION, 
                    "[\"view-private-information\"]");
                permissionSet.AddPermissions(ProfileAuthorizationPermissionLevel.PROFILE_GROUP, 
                    "[\"view-private-information\"]");
                permissionSet.AddPermissions(ProfileAuthorizationPermissionLevel.PROFILE_SUBGROUP, 
                    "[\"view-private-information\"]");
            };

            var expected = new ProfileAuthorizationPermissionSet();
            configurePermissionSet(expected);

            // Act
            var actual = _permissionService.GetProfilePermissions(verificationOptions);

            // Assert
            actual.GetPermissions().Should().BeEquivalentTo(expected.GetPermissions());
        }
    }
}