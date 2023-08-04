using educational_platform_api.Models;
using educational_platform_api.Repositories;
using FluentAssertions;
using Moq;

namespace educational_platform_api.Authorization.ProfileAuthorization.Tests
{
    [TestClass()]
    public class ProfileAuthorizationVerificationOptionsServiceShould
    {
        private readonly Mock<UnitOfWork> unitOfWorkMock;
        private readonly IProfileAuthorizationVerificationOptionsService verificationOptionsService;

        public ProfileAuthorizationVerificationOptionsServiceShould()
        {
            unitOfWorkMock = new Mock<UnitOfWork>();
            verificationOptionsService = new ProfileAuthorizationVerificationOptionsService(unitOfWorkMock.Object);
        }

        [TestMethod()]
        public void CheckOrganizationСorrespondenceAsExpectedWhenNoPropertiesProvided()
        {
            // Arrange
            Action<ProfileAuthorizationVerificationOptions> configure = (options) =>
            {
                options.AddPolicy("test-policy");
                options.AddProfile(1);
                options.AddOrganization();
            };
            var verificationOptions = new ProfileAuthorizationVerificationOptions();
            configure(verificationOptions);
            unitOfWorkMock
                .Setup(x => x.Organizations.GetByProfileId(It.IsAny<int>()))
                .Returns(new Organization { Id = 1 });

            // Act
            var act = verificationOptionsService.CheckOrganizationСorrespondence(verificationOptions);

            // Assert
            act.Should().BeTrue();
        }

        [TestMethod()]
        public void CheckOrganizationСorrespondenceAsExpectedWhenPropertiesProvided()
        {
            // Arrange
            Action<ProfileAuthorizationVerificationOptions> configure = (options) =>
            {
                options.AddPolicy("test-policy");
                options.AddProfile(1);
                options.AddGroup(1);
                options.AddOrganization();
            };
            var verificationOptions = new ProfileAuthorizationVerificationOptions();
            configure(verificationOptions);
            unitOfWorkMock
                .Setup(x => x.Organizations.GetByProfileId(It.IsAny<int>()))
                .Returns(new Organization { Id = 1 });
            unitOfWorkMock
                .Setup(x => x.Organizations.GetByGroupId(It.IsAny<int>()))
                .Returns(new Organization { Id = 1 });

            // Act
            var act = verificationOptionsService.CheckOrganizationСorrespondence(verificationOptions);

            // Assert
            act.Should().BeTrue();
        }
    }
}