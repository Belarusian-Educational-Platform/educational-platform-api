﻿using educational_platform_api.EntityFramework.TestData;
using Microsoft.EntityFrameworkCore;

namespace educational_platform_api.Extensions.EntityFramework.Configuration
{
    public static class TestDataExtension
    {
        public static ModelBuilder ApplyTestData(this ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProfileContextConfiguration());
            modelBuilder.ApplyConfiguration(new OrganizationContextConfiguration());
            modelBuilder.ApplyConfiguration(new GroupContextConfiguration());
            modelBuilder.ApplyConfiguration(new ProfileGroupRelationContextConfiguration());
            modelBuilder.ApplyConfiguration(new GroupOrganizationRelationContextConfiguration());
            modelBuilder.ApplyConfiguration(new ProfileOrganizationRelationContextConfiguration());

            return modelBuilder;
        }
    }
}
