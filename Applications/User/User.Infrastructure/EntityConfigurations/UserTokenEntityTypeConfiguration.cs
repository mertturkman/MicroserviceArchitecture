using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using User.Domain.AggregatesModel.UserAggregate;

namespace User.Infrastructure.EntityConfigurations
{
    public class UserTokenEntityTypeConfiguration : IEntityTypeConfiguration<UserToken>
    {
        public void Configure(EntityTypeBuilder<UserToken> builder)
        {
            builder.ToTable("UserToken", UserContext.DEFAULT_SCHEMA);
            builder.HasKey(userToken => userToken.Id);

            builder.Property(userToken => userToken.Id)
                .HasDefaultValueSql("uuid_generate_v4()");
            builder.Property(userToken => userToken.Token)
                .IsRequired();

            builder.HasOne(userToken => userToken.User)
                .WithMany(user => user.UserTokens)
                .HasForeignKey(userToken => userToken.UserId);

            builder.HasQueryFilter(userToken => !userToken.IsDeleted);
        }
    }
}
