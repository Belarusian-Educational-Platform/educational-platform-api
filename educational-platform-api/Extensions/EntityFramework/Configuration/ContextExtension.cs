using educational_platform_api.Models;
using Microsoft.EntityFrameworkCore;

namespace educational_platform_api.Extensions.EntityFramework.Configuration
{
    public static class ContextExtension
    {
        public static ModelBuilder ApplyPrimaryKeys(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Profile>()
                .HasKey(c => new { c.Id });
            modelBuilder.Entity<Group>()
               .HasKey(c => new { c.Id });
            modelBuilder.Entity<Organization>()
               .HasKey(c => new { c.Id });

            modelBuilder.Entity<ProfileGroupRelation>()
               .HasKey(c => new { c.ProfileId, c.GroupId });
            modelBuilder.Entity<GroupOrganizationRelation>()
               .HasKey(c => new { c.GroupId, c.OrganizationId });
            modelBuilder.Entity<ProfileOrganizationRelation>()
                .HasKey(c => new { c.ProfileId, c.OrganizationId });

            return modelBuilder;
        }

        public static ModelBuilder ApplyModelsRelations(this ModelBuilder modelBuilder)
        {
            // Profile-Organization relation
            modelBuilder.Entity<Profile>()
                .HasOne(p => p.OrganizationRelation)
                .WithOne(por => por.Profile)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Organization>()
                .HasMany(o => o.ProfileRelations)
                .WithOne(por => por.Organization)
                .OnDelete(DeleteBehavior.Cascade);

            // Profile-Group relation
            modelBuilder.Entity<Profile>()
                .HasMany(p => p.GroupRelations)
                .WithOne(pgr => pgr.Profile)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Group>()
                .HasMany(g => g.ProfileRelations)
                .WithOne(pgr => pgr.Group)
                .OnDelete(DeleteBehavior.Cascade);

            // Group-Organization relation
            modelBuilder.Entity<Group>()
                .HasOne(g => g.OrganizationRelation)
                .WithOne(gor => gor.Group)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Organization>()
                .HasMany(o => o.GroupRelations)
                .WithOne(gor => gor.Organization)
                .OnDelete(DeleteBehavior.Cascade);

            return modelBuilder;
        }

        public static ModelBuilder ApplyQueryFilters(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Profile>()
                .HasQueryFilter(x => x.IsDeleted == false);
            modelBuilder.Entity<Group>()
                .HasQueryFilter(x => x.IsDeleted == false);
            modelBuilder.Entity<Organization>()
                .HasQueryFilter(x => x.IsDeleted == false);

            modelBuilder.Entity<ProfileOrganizationRelation>()
                .HasQueryFilter(x => x.IsDeleted == false);
            modelBuilder.Entity<ProfileGroupRelation>()
                .HasQueryFilter(x => x.IsDeleted == false);
            modelBuilder.Entity<GroupOrganizationRelation>()
                .HasQueryFilter(x => x.IsDeleted == false);

            return modelBuilder;
        }
    }
}
