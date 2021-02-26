using MailNotification.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace MailNotification.Infrastructure.EntityConfigurations
{
    public class SentMailEntityTypeConfiguration : IEntityTypeConfiguration<SentMail>
    {
        public void Configure(EntityTypeBuilder<SentMail> builder)
        {
            builder.ToTable("SentMail", MailNotificationContext.DEFAULT_SCHEMA);
            builder.HasKey(sentMail => sentMail.Id);
            builder.Property(sentMail => sentMail.Status).IsRequired();
            builder.Property(sentMail => sentMail.To).IsRequired();
            builder.Property(sentMail => sentMail.From).IsRequired();
            builder.Property(sentMail => sentMail.Subject).IsRequired();
            builder.Property(sentMail => sentMail.Body).IsRequired();
            builder.Property(sentMail => sentMail.IsBodyHtml).IsRequired();
            builder.HasOne(sentMail => sentMail.MailTemplate)
                .WithMany(mailTemplate => mailTemplate.SentMails);
            
        }
    }
}
