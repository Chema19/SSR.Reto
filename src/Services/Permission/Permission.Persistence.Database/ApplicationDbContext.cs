using Microsoft.EntityFrameworkCore;
using Permission.Domain;
using Permission.Persistence.Database.Configurations;
using System;

namespace Permission.Persistence.Database
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Permissions> Permissionss { set; get; }
        public DbSet<PermissionTypes> PermissionTypess { set; get; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.HasDefaultSchema("Permission");
            ModelConfig(builder);
        }

        private void ModelConfig(ModelBuilder modelBuilder)
        {
            new PermissionConfiguration(modelBuilder.Entity<Permissions>());
            new PermissionTypesConfiguration(modelBuilder.Entity<PermissionTypes>());
        }
    }
}
