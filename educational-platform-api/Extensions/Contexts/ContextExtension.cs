﻿using educational_platform_api.Models;
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
            modelBuilder.Entity<Subgroup>()
               .HasKey(c => new { c.Id });
            modelBuilder.Entity<Organization>()
               .HasKey(c => new { c.Id });
            modelBuilder.Entity<Account>()
                .HasKey(c => new { c.Id });

            modelBuilder.Entity<ProfileGroupRelation>()
               .HasKey(c => new { c.ProfileId, c.GroupId });
            modelBuilder.Entity<GroupOrganizationRelation>()
               .HasKey(c => new { c.GroupId, c.OrganizationId });
            modelBuilder.Entity<ProfileSubgroupRelation>()
               .HasKey(c => new { c.ProfileId, c.SubgroupId });
            modelBuilder.Entity<ProfileOrganizationRelation>()
                .HasKey(c => new { c.ProfileId, c.OrganizationId });

            return modelBuilder;
        }
    }
}