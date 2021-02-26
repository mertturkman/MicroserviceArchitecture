using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using User.Domain.AggregatesModel.RoleAggregate;

namespace User.Infrastructure.EntityConfigurations
{
    public class RolePermissionTypeConfiguration : IEntityTypeConfiguration<RolePermission>
    {
        public void Configure(EntityTypeBuilder<RolePermission> builder)
        {
            builder.ToTable("RolePermission", UserContext.DEFAULT_SCHEMA);
            builder.HasKey(rolePermission => rolePermission.Id);

            builder.Property(rolePermission => rolePermission.Id)
                .HasDefaultValueSql("uuid_generate_v4()");

            builder.HasOne(rolePermission => rolePermission.Permission)
                .WithMany(permission => permission.RolePermissions)
                .HasForeignKey(rolePermission => rolePermission.PermissionId);

            builder.HasOne(rolePermission => rolePermission.Role)
                .WithMany(role => role.RolePermissions)
                .HasForeignKey(rolePermission => rolePermission.RoleId);

            builder.HasQueryFilter(rolePermission => !rolePermission.IsDeleted);
        }
    }
}
