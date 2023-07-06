using educational_platform_api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace educational_platform_api.TestData
{
    public class SubgroupContextConfiguration : IEntityTypeConfiguration<Subgroup>
    {
        public void Configure(EntityTypeBuilder<Subgroup> builder)
        {
            builder
                .HasData
                (
                    new Subgroup
                    {
                        Id = 1,
                        Name = "11B1",
                    },
                    new Subgroup
                    {
                        Id = 2,
                        Name = "9F1"
                    },
                    new Subgroup
                    {
                        Id = 3,
                        Name = "8Th1"
                    }
                );
        }
    }
}
