using educational_platform_api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace educational_platform_api.TestData
{
    public class OrganizationContextConfiguration : IEntityTypeConfiguration<Organization>
    {
        public void Configure(EntityTypeBuilder<Organization> builder)
        {
            builder
               .HasData(
                   new Organization
                   {
                       Id = 1,
                       Description = "Kyiv Natural Science Lyceum No. 145 is a secondary educational institution located in Pechersk District of Kyiv, Ukraine. The program of study emphasizes Physics, Mathematics, Computer Science and Chemistry1. The school’s address is 46 Shota Rustaveli Street Pechersk Raion , Kyiv , 01033 Ukraine1. ",
                       Name = "Kyiv Natural Science Lyceum No. 145",
                       Latitude = 53.893309,
                       Longitude = 27.567422
                   }, new Organization
                   {
                       Id = 2,
                       Description = "Meridian International School is a private school located in Kyiv, Ukraine. It was established in 20012. Unfortunately, I could not find the exact address or coordinates of the school.\r\n\r\n",
                       Name = "Meridian International School",
                       Latitude = 53.893034,
                       Longitude = 27.567444
                   }, new Organization
                   {
                       Id = 3,
                       Description = "Kyiv Secondary School No. 189 is a public school located in Kyiv, Ukraine. Unfortunately, I could not find any information on the program of study or the exact address or coordinates of the school.\r\n\r\n",
                       Name = "Kyiv Secondary School No. 189",
                       Latitude = 53.893034,
                       Longitude = 27.567454
                   }
               );
        }
    }
}
