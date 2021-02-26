using MailNotification.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MailNotification.Infrastructure
{
    public class MailNotificationContext: DbContext
    {
        public const string DEFAULT_SCHEMA = "public";

        public DbSet<MailTemplate> MailTemplates { get; set; }
        public DbSet<SentMail> SentMails { get; set; }

        private IDbContextTransaction _currentTransaction { get; set; }
        public IDbContextTransaction GetCurrentTransaction => _currentTransaction;

        public MailNotificationContext(DbContextOptions<MailNotificationContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        public bool SaveEntities(CancellationToken cancellationToken = default(CancellationToken))
        {
            int result = base.SaveChanges();
            return true;
        }

        public void BeginTransaction()
        {
            _currentTransaction = _currentTransaction ?? Database.BeginTransaction(IsolationLevel.ReadCommitted);
        }

        public void CommitTransactionAsync()
        {
            try
            {
                SaveChangesAsync();
                _currentTransaction?.Commit();
            }
            catch
            {
                RollbackTransaction();
                throw;
            }
            finally
            {
                if (_currentTransaction != null)
                {
                    _currentTransaction.Dispose();
                    _currentTransaction = null;
                }
            }
        }

        public void RollbackTransaction()
        {
            try
            {
                _currentTransaction?.Rollback();
            }
            finally
            {
                if (_currentTransaction != null)
                {
                    _currentTransaction.Dispose();
                    _currentTransaction = null;
                }
            }
        }
    }
}
