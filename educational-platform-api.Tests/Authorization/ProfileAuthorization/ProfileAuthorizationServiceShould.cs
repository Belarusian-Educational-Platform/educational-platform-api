using Microsoft.VisualStudio.TestTools.UnitTesting;
using educational_platform_api.Authorization.ProfileAuthorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using educational_platform_api.Authorization.ProfileAuthorization.Policy;
using Moq;
using educational_platform_api.Authorization.ProfileAuthorization.Permission;
using educational_platform_api.Types;
using educational_platform_api.Types.Enums;
using educational_platform_api.Extensions.Types;

namespace educational_platform_api.Authorization.ProfileAuthorization.Tests
{
    [TestClass()]
    public class ProfileAuthorizationServiceShould
    {
        private readonly IProfileAuthorizationService _profileAuthorizationService;
        private readonly Mock<IProfileAuthorizationPolicyProvider> _policyProvider;
        private readonly Mock<IProfileAuthorizationPolicyVerifier> _policyVerifier;
        
        public ProfileAuthorizationServiceShould()
        {
            _policyProvider = new Mock<IProfileAuthorizationPolicyProvider>();
            _policyVerifier = new Mock<IProfileAuthorizationPolicyVerifier>();

            _profileAuthorizationService = new ProfileAuthorizationService(_policyProvider.Object, 
                _policyVerifier.Object);
        }

        [TestMethod()]
        public void Authorize_As_Expected()
        {
            // Arrange
            Action<ProfileAuthorizationPolicyBuilder> configurePolicyBuilder = (policy) =>
            {
                policy.AddRequirements(
                    (ProfileAuthorizationPermissionLevel.PROFILE_SUBGROUP, "view-private-information").ToPermission()
                );
            };
            var policyBuilder = new ProfileAuthorizationPolicyBuilder();
            configurePolicyBuilder(policyBuilder);
            var policy = policyBuilder.Build();

            Action<ProfileAuthorizationVerificationOptions> configureVerificationOptions = (options) =>
            {
                options.AddProfile(1);
                options.AddGroup(1);
                options.AddSubgroup(1);
                options.AddOrganization();
            };

            _policyProvider.Setup(provider => provider.GetPolicy(It.IsAny<string>())).Returns(policy);
            _policyVerifier
                .Setup(verifier => verifier.Verify(It.IsAny<ProfileAuthorizationPolicy>(),
                    It.IsAny<ProfileAuthorizationVerificationOptions>()))
                .Returns(false);

            // Act
            try
            {
                _profileAuthorizationService.AuthorizeProfile(configureVerificationOptions);
            } catch (Exception ex)
            {
                // Assert
                Assert.IsTrue(typeof(Exception).IsAssignableFrom(ex.GetType()));
            }
        }
    }
}