using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using User.Domain.AggregatesModel.UserAggregate;

namespace User.Infrastructure.EntityConfigurations {
    public class UserEntityTypeConfiguration : IEntityTypeConfiguration<Domain.AggregatesModel.UserAggregate.User> {
        public void Configure (EntityTypeBuilder<Domain.AggregatesModel.UserAggregate.User> builder) {
            builder.ToTable ("User", UserContext.DEFAULT_SCHEMA);
            builder.HasKey (user => user.Id);

            builder.HasIndex(user => new { user.Username, user.Password })
                .IsUnique();
            builder.HasIndex(user => user.Username)
                .IsUnique();
            builder.HasIndex(user => user.Mail)
                .IsUnique();

            builder.Property(user => user.Id)
                .HasDefaultValueSql("uuid_generate_v4()");
            builder.Property(user => user.Name)
                .IsRequired();
            builder.Property(user => user.Surname)
                .IsRequired();
            builder.Property(user => user.Username)
                .IsRequired();
            builder.Property (user => user.Password)
                .IsRequired();
            builder.Property (user => user.Mail)
                .IsRequired();

            builder.OwnsOne(user => user.Address);
            builder.HasQueryFilter(user => !user.IsDeleted);
        }
    }
}