using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using api.Models;
using api.Types.Enums;

namespace api.EntityFramework.TestData
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
                    KeycloakId = "c9c5c403-280e-491a-9217-e60a04022b7f",

                    FirstName = "Daniil",
                    LastName = "Kananenka",
                    Surname = "Alexandrovich",
                    Birthday = new DateTime(2004, 11, 25),

                    ContactEmail = "hotjames4u@quebecstart.com",
                    ContactPhone = "+375 29 403-72-60",

                    Type = ProfileType.student,
                    IsActive = true,
                },
                new Profile
                {
                    Id = 2,
                    KeycloakId = "c9c5c403-280e-491a-9217-e60a04022b7f",

                    FirstName = "Karyna",
                    LastName = "Novik",
                    Surname = "Tsimur",
                    Birthday = new DateTime(2010, 7, 21),

                    ContactEmail = "reiianx@gasss.net",
                    ContactPhone = "+375 44 164-23-69",

                    Type = ProfileType.student,
                    IsActive = false,
                },
                new Profile
                {
                    Id = 3,
                    KeycloakId = "c9c5c403-280e-491a-9217-e60a04022b7g",

                    FirstName = "Tsimur",
                    LastName = "Kavalioŭ",
                    Surname = "Henadz",
                    Birthday = new DateTime(1990, 1, 24),

                    ContactEmail = "kxarmark@cbdnut.net",
                    ContactPhone = "+375 29 352-28-10",

                    Type = ProfileType.organizationEmployee,
                    IsActive = true,
                },
                new Profile
                {
                    Id = 4,
                    KeycloakId = "c9c5c403-280e-491a-9217-e60a04022b7g",

                    FirstName = "Artur",
                    LastName = "Kazlow",
                    Surname = " Iryna",
                    Birthday = new DateTime(2008, 6, 20),

                    ContactEmail = "imamikonyan@sannyfeina.art",
                    ContactPhone = "+375 33 938-46-86",

                    Type = ProfileType.student,
                    IsActive = false,
                },
                new Profile
                {
                    Id = 5,
                    KeycloakId = "c9c5c403-280e-491a-9217-e60a04022b7g",

                    FirstName = "Yan",
                    LastName = "Kavalioŭ",
                    Surname = "Marta",
                    Birthday = new DateTime(1975, 4, 2),

                    ContactEmail = "franicomunication@gmisow.com",
                    ContactPhone = "+375 29 609-07-74",

                    Type = ProfileType.organizationEmployee,
                    IsActive = false,
                },
                new Profile
                {
                    Id = 6,
                    KeycloakId = "c9c5c403-280e-491a-9217-e60a04022b7c",

                    FirstName = "Karyna",
                    LastName = "Ivanow",
                    Surname = " Ilia",
                    Birthday = new DateTime(2011, 8, 5),

                    ContactEmail = "psylio@yagatekimi.com",
                    ContactPhone = "+375 29 415-46-04",

                    Type = ProfileType.student,
                    IsActive = true,
                },
                new Profile
                {
                    Id = 7,
                    KeycloakId = "c9c5c403-280e-491a-9217-e60a04022b7c",

                    FirstName = "Hleb",
                    LastName = "Ivanow",
                    Surname = "Kira",
                    Birthday = new DateTime(1994, 8, 15),

                    ContactEmail = "zulu54@pankasyno23.com",
                    ContactPhone = "+375 29 865-01-63",

                    Type = ProfileType.organizationEmployee,
                    IsActive = true,
                }
                );
        }
    }
}
