using User.Domain.AggregatesModel.RoleAggregate;
using User.Domain.AggregatesModel.UserAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace User.Infrastructure.EntityConfigurations {
    public class UserRoleTypeConfiguration : IEntityTypeConfiguration<UserRole> {
        public void Configure (EntityTypeBuilder<UserRole> builder) {
            builder.ToTable("UserRole", UserContext.DEFAULT_SCHEMA);
            builder.HasKey(userRole => userRole.Id);

            builder.Property(userRole => userRole.Id)
                .HasDefaultValueSql("uuid_generate_v4()");

            builder.HasOne(userRole => userRole.User)
                .WithMany(user => user.UserRoles)
                .HasForeignKey(user => user.UserId);
            builder.HasOne(userRole => userRole.Role)
                .WithMany(role => role.UserRoles)
                .HasForeignKey(userRole => userRole.RoleId);

            builder.HasQueryFilter(userRole => !userRole.IsDeleted);
        }
    }
}