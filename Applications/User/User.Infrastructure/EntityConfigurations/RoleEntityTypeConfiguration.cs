using User.Domain.AggregatesModel.RoleAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace User.Infrastructure.EntityConfigurations
{
    public class RoleEntityTypeConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("Role", UserContext.DEFAULT_SCHEMA);
            builder.HasKey(role => role.Id);
            builder.HasIndex(role => role.Name)
                .IsUnique();

            builder.Property(role => role.Id)
                .HasDefaultValueSql("uuid_generate_v4()");
            builder.Property(role => role.Name)
                .IsRequired();

            builder.HasQueryFilter(role => !role.IsDeleted);
        }
    }
}