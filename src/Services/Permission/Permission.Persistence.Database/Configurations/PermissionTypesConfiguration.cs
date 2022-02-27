using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Permission.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Permission.Persistence.Database.Configurations
{
    public class PermissionTypesConfiguration
    {
        public PermissionTypesConfiguration(EntityTypeBuilder<PermissionTypes> entityBuilder)
        {
            entityBuilder.HasIndex(x => x.Id);
            entityBuilder.Property(x => x.Description).IsRequired().HasMaxLength(1000);
        }
    }
}
