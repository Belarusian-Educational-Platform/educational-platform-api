using educational_platform_api.Authorization.ProfileAuthorization.Policy;
using educational_platform_api.Extensions.Types;
using educational_platform_api.Types.Enums;
using FluentAssertions;

namespace educational_platform_api.Authorization.ProfileAuthorization.Tests
{
    [TestClass()]
    public class ProfileAuthorizationOptionsShould
    {
        [TestMethod()]
        public void Add_Policy_As_Expected()
        {
            // Arrange
            string policyName = "test-policy";
            Action<ProfileAuthorizationPolicyBuilder> configurePolicyBuilder = (policy) =>
            {
                policy.AddRequirements(
                    (ProfileAuthorizationPermissionLevel.PROFILE_ORGANIZATION, "view-private-information")
                    .ToPermission());
            };
            var policyBuilder = new ProfileAuthorizationPolicyBuilder();
            configurePolicyBuilder(policyBuilder);
            var expected = policyBuilder.Build();

            var authorizationOptions = new ProfileAuthorizationOptions();

            // Act
            authorizationOptions.AddPolicy(policyName, configurePolicyBuilder);

            // Assert
            authorizationOptions.ProfilePolicyMap[policyName].Should().BeEquivalentTo(expected); 
        }
    }
}