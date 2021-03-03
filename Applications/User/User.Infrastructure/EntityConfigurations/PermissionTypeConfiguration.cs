using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using User.Domain.AggregatesModel.PermissionAggregate;

namespace User.Infrastructure.EntityConfigurations
{
    public class PermissionTypeConfiguration : IEntityTypeConfiguration<Permission>
    {
        public void Configure(EntityTypeBuilder<Permission> builder)
        {
            builder.ToTable("Permission", UserContext.DEFAULT_SCHEMA);
            builder.HasKey(permission => permission.Id);
            builder.HasIndex(permission => permission.Name);
                
            builder.Property(permission => permission.Id)
                .HasDefaultValueSql("uuid_generate_v4()");
            builder.Property(permission => permission.Name)
                .IsRequired();
            builder.Property(permission => permission.Code)
                .IsRequired();

            builder.HasQueryFilter(permission => !permission.IsDeleted);
        }
    }
}
