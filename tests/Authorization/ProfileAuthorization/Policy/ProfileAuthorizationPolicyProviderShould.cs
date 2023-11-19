using Microsoft.VisualStudio.TestTools.UnitTesting;
using educational_platform_api.Authorization.ProfileAuthorization.Policy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Moq;
using educational_platform_api.Types.Enums;
using educational_platform_api.Extensions.Types;
using FluentAssertions;

namespace educational_platform_api.Authorization.ProfileAuthorization.Policy.Tests
{
    [TestClass()]
    public class ProfileAuthorizationPolicyProviderShould
    {
        [TestMethod()]
        public void Get_Policy_As_Expected()
        {
            // Arrange
            var authorizationOptions = new ProfileAuthorizationOptions();
            Action<ProfileAuthorizationPolicyBuilder> configurePolicyBuilder = (policy) =>
            {
                policy.AddRequirements(
                   (ProfileAuthorizationPermissionLevel.PROFILE_GROUP, "view-private-information").ToPermission()
                );
            };
            var policyBuilder = new ProfileAuthorizationPolicyBuilder();
            configurePolicyBuilder(policyBuilder);

            string expectedPolicyName = "get-group";
            var expected = policyBuilder.Build();

            authorizationOptions.AddPolicy(expectedPolicyName, configurePolicyBuilder);

            var options = new Mock<IOptions<ProfileAuthorizationOptions>>();
            options.Setup(x => x.Value).Returns(authorizationOptions);

            var policyProvider = new ProfileAuthorizationPolicyProvider(options.Object);

            // Act
            var actual = policyProvider.GetPolicy(expectedPolicyName);

            // Assert
            actual.Should().BeEquivalentTo(expected);
        }
    }
}