using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using educational_platform_api.Models;
using educational_platform_api.Types.Enums;

namespace educational_platform_api.TestData
{
    public class ProfileContextConfiguration : IEntityTypeConfiguration<Profile>
    {
        public void Configure(EntityTypeBuilder<Profile> builder)
        {
            builder
                .HasData(
                new Profile
                {
                    Id = 1,
                    ContactEmail = "hotjames4u@quebecstart.com",
                    ContactPhone = "+375 29 403-72-60",
                    Type = ProfileType.student, 
                    OrganizationId = 1,
                    KeycloakId = "c9c5c403-280e-491a-9217-e60a04022b7f",
                    IsActive = true,
                },
                new Profile
                {
                    Id = 2,
                    ContactEmail = "reiianx@gasss.net",
                    ContactPhone = "+375 44 164-23-69",
                    Type = ProfileType.student,
                    OrganizationId = 1,
                    KeycloakId = "c9c5c403-280e-491a-9217-e60a04022b7f",
                    IsActive = false,
                },
                new Profile
                {
                    Id = 3,
                    ContactEmail = "kxarmark@cbdnut.net",
                    ContactPhone = "+375 29 352-28-10",
                    Type = ProfileType.organizationEmployee,
                    OrganizationId = 1,
                    KeycloakId = "c9c5c403-280e-491a-9217-e60a04022b7g",
                    IsActive = true,
                },
                new Profile
                {
                    Id = 4,
                    ContactEmail = "imamikonyan@sannyfeina.art",
                    ContactPhone = "+375 33 938-46-86",
                    Type = ProfileType.student,
                    OrganizationId = 2,
                    KeycloakId = "c9c5c403-280e-491a-9217-e60a04022b7g",
                    IsActive = false,
                },
                new Profile
                {
                    Id = 5,
                    ContactEmail = "franicomunication@gmisow.com",
                    ContactPhone = "+375 29 609-07-74",
                    Type = ProfileType.organizationEmployee,
                    OrganizationId = 2,
                    KeycloakId = "c9c5c403-280e-491a-9217-e60a04022b7g",
                    IsActive = false,
                },
                new Profile
                {
                    Id = 6,
                    ContactEmail = "psylio@yagatekimi.com",
                    ContactPhone = "+375 29 415-46-04",
                    Type = ProfileType.student,
                    OrganizationId = 3,
                    KeycloakId = "c9c5c403-280e-491a-9217-e60a04022b7c",
                    IsActive = true,
                },
                new Profile
                {
                    Id = 7,
                    ContactEmail = "zulu54@pankasyno23.com",
                    ContactPhone = "+375 29 865-01-63",
                    Type = ProfileType.organizationEmployee,
                    OrganizationId = 3,
                    KeycloakId = "c9c5c403-280e-491a-9217-e60a04022b7c",
                    IsActive = true,
                }
                );
        }
    }
}
