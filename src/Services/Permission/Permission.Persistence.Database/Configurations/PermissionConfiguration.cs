using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Permission.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Permission.Persistence.Database.Configurations
{
    public class PermissionConfiguration
    {
        public PermissionConfiguration(EntityTypeBuilder<Permissions> entityBuilder)
        {
            entityBuilder.HasIndex(x => x.Id);
            entityBuilder.Property(x => x.EmployeeForename).IsRequired().HasMaxLength(500);
            entityBuilder.Property(x => x.EmployeeSurname).IsRequired().HasMaxLength(500);
            entityBuilder.HasKey(x => x.PermissionType);
            entityBuilder.Property(x => x.PermissionDate).IsRequired();
        }
    }
}
