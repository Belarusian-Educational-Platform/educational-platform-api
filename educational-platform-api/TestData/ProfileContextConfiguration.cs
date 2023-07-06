using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using educational_platform_api.Models;

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
                    ProfileType = "student",
                    OrganizationId = 1,
                    AccountId= 1,
                },
                new Profile
                {
                    Id = 2,
                    ContactEmail = "reiianx@gasss.net",
                    ContactPhone = "+375 44 164-23-69",
                    ProfileType = "student",
                    OrganizationId = 1,
                    AccountId = 2,
                },
                new Profile
                {
                    Id = 3,
                    ContactEmail = "kxarmark@cbdnut.net",
                    ContactPhone = "+375 29 352-28-10",
                    ProfileType = "Teacher",
                    OrganizationId = 1,
                    AccountId = 3,
                },
                new Profile
                {
                    Id = 4,
                    ContactEmail = "imamikonyan@sannyfeina.art",
                    ContactPhone = "+375 33 938-46-86",
                    ProfileType = "student",
                    OrganizationId = 2,
                    AccountId = 4,
                },
                new Profile
                {
                    Id = 5,
                    ContactEmail = "franicomunication@gmisow.com",
                    ContactPhone = "+375 29 609-07-74",
                    ProfileType = "Teacher",
                    OrganizationId = 2,
                    AccountId = 5,
                },
                new Profile
                {
                    Id = 6,
                    ContactEmail = "psylio@yagatekimi.com",
                    ContactPhone = "+375 29 415-46-04",
                    ProfileType = "student",
                    OrganizationId = 3,
                    AccountId = 6,
                },
                new Profile
                {
                    Id = 7,
                    ContactEmail = "zulu54@pankasyno23.com",
                    ContactPhone = "+375 29 865-01-63",
                    ProfileType = "Teacher",
                    OrganizationId = 3,
                    AccountId = 7,
                }
                );
        }
    }
}
