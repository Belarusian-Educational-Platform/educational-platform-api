using educational_platform_api.Types.Enums;
using FluentAssertions;

namespace educational_platform_api.Authorization.ProfileAuthorization.Tests
{
    [TestClass()]
    public class ProfileAuthorizationVerificationOptionsShould
    {
        [TestMethod()]
        public void Add_Policy_As_Expected()
        {
            // Arrange
            string policyName = "test-policy";
            var verificationOptions = new ProfileAuthorizationVerificationOptions();

            // Act
            verificationOptions.AddPolicy(policyName);

            // Assert
            verificationOptions.PolicyName.Should().Be(policyName);
        }

        [TestMethod()]
        public void Add_Profile_As_Expected()
        {
            // Arrange
            int profileId = 1;
            var verificationOptions = new ProfileAuthorizationVerificationOptions();

            // Act
            verificationOptions.AddProfile(profileId);

            // Assert
            verificationOptions.ProfileId.Should().Be(profileId);
        }

        [TestMethod()]
        public void Add_Group_As_Expected()
        {
            // Arrange
            int groupId = 1;
            var verificationOptions = new ProfileAuthorizationVerificationOptions();

            // Act
            verificationOptions.AddGroup(groupId);

            // Assert
            verificationOptions.GroupId.Should().Be(groupId);
            verificationOptions.VerificationLevels
                .Should()
                .Contain(ProfileAuthorizationPermissionLevel.PROFILE_GROUP);
        }

        [TestMethod()]
        public void Add_Subgroup_As_Expected()
        {
            // Arrange
            int subgroupId = 1;
            var verificationOptions = new ProfileAuthorizationVerificationOptions();

            // Act
            verificationOptions.AddSubgroup(subgroupId);

            // Assert
            verificationOptions.SubgroupId.Should().Be(subgroupId);
            verificationOptions.VerificationLevels
                .Should()
                .Contain(ProfileAuthorizationPermissionLevel.PROFILE_SUBGROUP);
        }

        [TestMethod()]
        public void Add_Organization_As_Expected()
        {
            // Arrange
            var verificationOptions = new ProfileAuthorizationVerificationOptions();

            // Act
            verificationOptions.AddOrganization();

            // Assert
            verificationOptions.VerificationLevels
                .Should()
                .Contain(ProfileAuthorizationPermissionLevel.PROFILE_ORGANIZATION);
        }
    }
}