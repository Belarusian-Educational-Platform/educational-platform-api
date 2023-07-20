using educational_platform_api.Authorization.ProfileAuthorization.Permission;
using educational_platform_api.Extensions.Types;
using educational_platform_api.Types.Enums;
using FluentAssertions;
using Moq;

namespace educational_platform_api.Authorization.ProfileAuthorization.Policy.Tests
{
    [TestClass()]
    public class ProfileAuthorizationPolicyVerifierShould
    {
        private readonly IProfileAuthorizationPolicyVerifier _policyVerifier;
        private readonly Mock<IProfileAuthorizationPermissionService> _permissionService;

        public ProfileAuthorizationPolicyVerifierShould()
        {
            _permissionService = new Mock<IProfileAuthorizationPermissionService>();
            _policyVerifier = new ProfileAuthorizationPolicyVerifier(_permissionService.Object);
        }

        [TestMethod()]
        public void Throw_Exception_When_Verification_Options_Not_Suitable_For_Policy_While_Verifying()
        {
            // Arrange
            Action<ProfileAuthorizationVerificationOptions> configureVerificationOptions = (options) =>
            {
                options.AddPolicy("test-policy");
                options.AddProfile(1);
                options.AddGroup(1);
                options.AddSubgroup(1);
            };

            Action<ProfileAuthorizationPolicyBuilder> configurePolicyBuilder = (policy) =>
            {
                policy.AddRequirements(
                    (ProfileAuthorizationPermissionLevel.PROFILE_ORGANIZATION, "view-private-information").ToPermission()
                );
            };

            var verificationOptions = new ProfileAuthorizationVerificationOptions();
            configureVerificationOptions(verificationOptions);
            var policyBuilder = new ProfileAuthorizationPolicyBuilder();
            configurePolicyBuilder(policyBuilder);
            var policy = policyBuilder.Build();

            // Act
            Action action = () => { _policyVerifier.Verify(policy, verificationOptions); };

            // Assert
            action.Should().Throw<Exception>();
        }

        [TestMethod()]
        public void Return_False_On_Requirement_Check_While_Verifying()
        {
            // Arrange
            Action<ProfileAuthorizationVerificationOptions> configureVerificationOptions = (options) =>
            {
                options.AddPolicy("test-policy");
                options.AddProfile(1);
                options.AddOrganization();
            };

            Action<ProfileAuthorizationPolicyBuilder> configurePolicyBuilder = (policy) =>
            {
                policy.AddRequirements(
                    (ProfileAuthorizationPermissionLevel.PROFILE_ORGANIZATION, "view-private-information").ToPermission()
                );
            };

            var verificationOptions = new ProfileAuthorizationVerificationOptions();
            configureVerificationOptions(verificationOptions);
            var policyBuilder = new ProfileAuthorizationPolicyBuilder();
            configurePolicyBuilder(policyBuilder);
            var policy = policyBuilder.Build();

            Action<ProfileAuthorizationPermissionSet> configurePermissionSet = (permissions) =>
            {
                permissions.AddPermissions(ProfileAuthorizationPermissionLevel.PROFILE_ORGANIZATION, 
                    "[\"create-profiles\"]");
            };
            var profilePermissionSet = new ProfileAuthorizationPermissionSet();
            configurePermissionSet(profilePermissionSet);

            _permissionService
                .Setup(service => service.GetProfilePermissions(It.IsAny<ProfileAuthorizationVerificationOptions>()))
                .Returns(profilePermissionSet);

            // Act
            bool action = _policyVerifier.Verify(policy, verificationOptions);

            // Assert
            action.Should().BeFalse();
        }

        [TestMethod()]
        public void Return_False_On_Asserion_Check_While_Verifying()
        {
            // Arrange
            Action<ProfileAuthorizationVerificationOptions> configureVerificationOptions = (options) =>
            {
                options.AddPolicy("test-policy");
                options.AddProfile(1);
                options.AddOrganization();
            };

            Action<ProfileAuthorizationPolicyBuilder> configurePolicyBuilder = (policy) =>
            {
                policy.RequireAssertion(process =>
                    process((ProfileAuthorizationPermissionLevel.PROFILE_ORGANIZATION, 
                        "view-private-information").ToPermission())
                );
            };

            var verificationOptions = new ProfileAuthorizationVerificationOptions();
            configureVerificationOptions(verificationOptions);

            var policyBuilder = new ProfileAuthorizationPolicyBuilder();
            configurePolicyBuilder(policyBuilder);
            var policy = policyBuilder.Build();

            Action<ProfileAuthorizationPermissionSet> configurePermissionSet = (permissions) =>
            {
                permissions.AddPermissions(ProfileAuthorizationPermissionLevel.PROFILE_ORGANIZATION,
                    "[\"create-profiles\"]");
            };
            var profilePermissionSet = new ProfileAuthorizationPermissionSet();
            configurePermissionSet(profilePermissionSet);

            _permissionService
                .Setup(service => service.GetProfilePermissions(It.IsAny<ProfileAuthorizationVerificationOptions>()))
                .Returns(profilePermissionSet);

            // Act
            bool action = _policyVerifier.Verify(policy, verificationOptions);

            // Assert
            action.Should().BeFalse();
        }

        [TestMethod()]
        public void Verify_As_Expected()
        {
            // Arrange
            Action<ProfileAuthorizationVerificationOptions> configureVerificationOptions = (options) =>
            {
                options.AddPolicy("test-policy");
                options.AddProfile(1);
                options.AddOrganization();
            };

            Action<ProfileAuthorizationPolicyBuilder> configurePolicyBuilder = (policy) =>
            {
                policy.AddRequirements(
                    (ProfileAuthorizationPermissionLevel.PROFILE_ORGANIZATION, "view-private-information").ToPermission()
                );
                policy.RequireAssertion(process =>
                    process((ProfileAuthorizationPermissionLevel.PROFILE_ORGANIZATION, 
                        "view-private-information").ToPermission())
                );
            };

            var verificationOptions = new ProfileAuthorizationVerificationOptions();
            configureVerificationOptions(verificationOptions);
            var policyBuilder = new ProfileAuthorizationPolicyBuilder();
            configurePolicyBuilder(policyBuilder);
            var policy = policyBuilder.Build();

            Action<ProfileAuthorizationPermissionSet> configurePermissionSet = (permissions) =>
            {
                permissions.AddPermissions(ProfileAuthorizationPermissionLevel.PROFILE_ORGANIZATION,
                    "[\"view-private-information\"]");
            };
            var profilePermissionSet = new ProfileAuthorizationPermissionSet();
            configurePermissionSet(profilePermissionSet);

            _permissionService
                .Setup(service => service.GetProfilePermissions(It.IsAny<ProfileAuthorizationVerificationOptions>()))
                .Returns(profilePermissionSet);

            // Act
            bool action = _policyVerifier.Verify(policy, verificationOptions);

            // Assert
            action.Should().BeTrue();
        }
    }
}