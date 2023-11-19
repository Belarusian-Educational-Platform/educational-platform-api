using api.Extensions.EntityFramework.Configuration;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.EntityFramework.Contexts
{
    public class MySQLContext : DbContext
    {
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<ProfileGroupRelation> ProfileGroupRelations { get; set; }
        public DbSet<GroupOrganizationRelation> GroupOrganizationRelations { get; set; }
        public DbSet<ProfileOrganizationRelation> ProfileOrganizationRelations { get; set; }

        public MySQLContext(DbContextOptions<MySQLContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .ApplyTestData()
                .ApplyPrimaryKeys()
                .ApplyModelsRelations()
                .ApplyQueryFilters();
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            ChangeTracker.SetAuditProperties();
            return await base.SaveChangesAsync(cancellationToken);
        }

        public override async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            ChangeTracker.SetAuditProperties();
            return await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        public override int SaveChanges()
        {
            ChangeTracker.SetAuditProperties();
            return base.SaveChanges();
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            ChangeTracker.SetAuditProperties();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }
    }
}
