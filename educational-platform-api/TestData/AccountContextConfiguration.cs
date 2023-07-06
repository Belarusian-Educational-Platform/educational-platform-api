using educational_platform_api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace educational_platform_api.TestData
{
    public class AccountContextConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.HasData(
                 new Account
                 {
                     Id = 1,
                     Username= "Acrodocon",
                     FirstName = "Ulyana",
                     LastName = "Novik",
                     Surname = "Kanstantsin",
                     Birthday = new DateTime(2004, 11, 25),
                     Email = "hotjames4u@quebecstart.com",
                     KeycloakId = "5e977527 - d00d - 42d3 - 9a4d - b2163352f05a"
                 },
                new Account
                {
                    Id = 2,
                    Username = "DialFule",
                    FirstName = "Karyna",
                    LastName = "Novik",
                    Surname = "Tsimur",
                    Birthday = new DateTime(2010, 7, 21),
                    Email = "reiianx@gasss.net",
                    KeycloakId = "5e977527 - d00d - 42d3 - 9a4d - b2163352f05a"
                },
                new Account
                {
                    Id = 3,
                    Username = "AGiseNTi",
                    FirstName = "Tsimur",
                    LastName = "Kavalioŭ",
                    Surname = "Henadz",
                    Birthday = new DateTime(1990, 1, 24),
                    Email = "kxarmark@cbdnut.net",
                    KeycloakId = "5e977527 - d00d - 42d3 - 9a4d - b2163352f05a"
                },
                new Account
                {
                    Id = 4,
                    Username = "OnViTITr",
                    FirstName = "Artur",
                    LastName = "Kazlow",
                    Surname = " Iryna",
                    Birthday = new DateTime(2008, 6, 20),
                    Email = "imamikonyan@sannyfeina.art",
                    KeycloakId = "5e977527 - d00d - 42d3 - 9a4d - b2163352f05a"
                },
                new Account
                {
                    Id = 5,
                    Username = "LaCoLite",
                    FirstName = "Yan",
                    LastName = "Kavalioŭ",
                    Surname = "Marta",
                    Birthday = new DateTime(1975, 4, 2),
                    Email = "franicomunication@gmisow.com",
                    KeycloakId = "5e977527 - d00d - 42d3 - 9a4d - b2163352f05a"
                },
                new Account
                {
                    Id = 6,
                    Username = "LIEnuMiE",
                    FirstName = "Karyna",
                    LastName = "Ivanow",
                    Surname = " Ilia",
                    Birthday = new DateTime(2011, 8, 5),
                    Email = "psylio@yagatekimi.com",
                    KeycloakId = "5e977527 - d00d - 42d3 - 9a4d - b2163352f05a"
                },
                new Account
                {
                    Id = 7,
                    Username = "NEtrATEl",
                    FirstName = "Hleb",
                    LastName = "Ivanow",
                    Surname = "Kira",
                    Birthday = new DateTime(1994, 8, 15),
                    Email = "zulu54@pankasyno23.com",
                    KeycloakId = "5e977527 - d00d - 42d3 - 9a4d - b2163352f05a"
                });
        }
    }
}
