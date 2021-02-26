using MailNotification.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace MailNotification.Infrastructure.Configurations
{
    public class MailTemplateEntityTypeConfiguration : IEntityTypeConfiguration<MailTemplate>
    {
        public void Configure(EntityTypeBuilder<MailTemplate> builder)
        {
            builder.ToTable("MailTemplate", MailNotificationContext.DEFAULT_SCHEMA);
            builder.HasKey(mailTemplate => mailTemplate.Name);
            builder.Property(mailTemplate => mailTemplate.Subject).IsRequired();
            builder.Property(mailTemplate => mailTemplate.Body).IsRequired();
            builder.Property(mailTemplate => mailTemplate.IsBodyHtml).IsRequired().HasDefaultValue(false);
        }
    }
}
