using educational_platform_api.Models;
using Microsoft.EntityFrameworkCore;

namespace educational_platform_api.Extensions.Contexts
{
    public static class ContextExtension
    {
        public static ModelBuilder AddModelsPrimaryKeys(this ModelBuilder modelBuilder)
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

        public static ModelBuilder AddModelsRelations(this ModelBuilder modelBuilder)
        {
            // Profile-Organization relation
            modelBuilder.Entity<Profile>()
                .HasOne(p => p.OrganizationRelation).WithOne(por => por.Profile);
            modelBuilder.Entity<Organization>()
                .HasMany(o => o.ProfileRelations).WithOne(por => por.Organization);

            // Profile-Group relation
            modelBuilder.Entity<Profile>()
                .HasMany(p => p.GroupRelations).WithOne(pgr => pgr.Profile);
            modelBuilder.Entity<Group>()
                .HasMany(g => g.ProfileRelations).WithOne(pgr => pgr.Group);

            // Group-Organization relation
            modelBuilder.Entity<Group>()
                .HasOne(g => g.OrganizationRelation).WithOne(gor => gor.Group);
            modelBuilder.Entity<Organization>()
                .HasMany(o => o.GroupRelations).WithOne(gor => gor.Organization);
            

            return modelBuilder;
        }
    }
}
