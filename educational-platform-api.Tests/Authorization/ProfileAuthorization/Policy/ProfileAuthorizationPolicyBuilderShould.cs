using educational_platform_api.Authorization.ProfileAuthorization.Permission;
using educational_platform_api.Extensions.Types;
using educational_platform_api.Types;
using educational_platform_api.Types.Enums;
using FluentAssertions;

namespace educational_platform_api.Authorization.ProfileAuthorization.Policy.Tests
{
    [TestClass()]
    public class ProfileAuthorizationPolicyBuilderShould
    {
        [TestMethod()]
        public void Build_Policy_As_Expected()
        {
            // Arrange
            var builder = new ProfileAuthorizationPolicyBuilder();
            var requirements = new ProfileAuthorizationPermission[]
            {
                (ProfileAuthorizationPermissionLevel.PROFILE_SUBGROUP, "view-private-information").ToPermission(),
                (ProfileAuthorizationPermissionLevel.PROFILE_ORGANIZATION, "view-private-information").ToPermission()
            };
            var assertions = new List<AssertionPredicate>()
            {
                process =>
                    process((ProfileAuthorizationPermissionLevel.PROFILE_GROUP, "view-private-information")
                        .ToPermission())
            };
            var verificationLevels = new HashSet<ProfileAuthorizationPermissionLevel>()
            {
                ProfileAuthorizationPermissionLevel.PROFILE_ORGANIZATION,
                ProfileAuthorizationPermissionLevel.PROFILE_GROUP,
                ProfileAuthorizationPermissionLevel.PROFILE_SUBGROUP
            };

            builder.AddRequirements(requirements);
            foreach (var asserion in assertions)
            {
                builder.RequireAssertion(asserion);
            }

            var expected = new ProfileAuthorizationPolicy(requirements.ToList(), assertions, verificationLevels);

            // Act
            var actual = builder.Build();

            // Assert
            actual.Should().BeEquivalentTo(expected);
        }
    }
}