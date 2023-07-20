using educational_platform_api.Extensions.Types;
using educational_platform_api.Types.Enums;
using FluentAssertions;
using Moq;

namespace educational_platform_api.Authorization.ProfileAuthorization.Permission.Tests
{
    [TestClass()]
    public class ProfileAuthorizationPermissionSetShould
    {
        [TestMethod()]
        public void Add_Permissions_As_Expected()
        {
            // Arrange
            var permissionSetMock = new Mock<ProfileAuthorizationPermissionSet>();
            var permissionLevel = ProfileAuthorizationPermissionLevel.PROFILE_ORGANIZATION;
            string permissionsRaw = "[\"view-private-information\", \"create-profiles\"]";

            var expectedPermissionHashSet = new HashSet<ProfileAuthorizationPermission>
            {
                (permissionLevel, "view-private-information").ToPermission(),
                (permissionLevel, "create-profiles").ToPermission()
            };

            var permissionSet = permissionSetMock.Object;

            // Act
            permissionSet.AddPermissions(permissionLevel, permissionsRaw);

            // Assert
            permissionSet.GetPermissions().Should().BeEquivalentTo(expectedPermissionHashSet);
        }

        [TestMethod()]
        public void Check_Permission_Existance_As_Expected()
        {
            // Arrange
            var permissionSetMock = new Mock<ProfileAuthorizationPermissionSet>();
            var permissionLevel = ProfileAuthorizationPermissionLevel.PROFILE_ORGANIZATION;
            string permissionsRaw = "[\"view-private-information\", \"create-profiles\"]";
            var permissionForCheck = (permissionLevel, "view-private-information").ToPermission();

            var permissionSet = permissionSetMock.Object;

            permissionSet.AddPermissions(permissionLevel, permissionsRaw);

            // Act
            bool actual = permissionSet.HasPermission(permissionForCheck);

            // Assert
            actual.Should().BeTrue();
        }
    }
}