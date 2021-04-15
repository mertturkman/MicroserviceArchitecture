using System.Data;
using System.Threading;
using System.Threading.Tasks;
using User.Domain.AggregatesModel.RoleAggregate;
using User.Domain.AggregatesModel.UserAggregate;
using User.Domain.SeedWork;
using User.Infrastructure.EntityConfigurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using User.Domain.AggregatesModel.PermissionAggregate;
using System;

namespace User.Infrastructure {
    public class UserContext : DbContext, IUnitOfWork {
        public const string DEFAULT_SCHEMA = "public";
        public DbSet<User.Domain.AggregatesModel.UserAggregate.User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<RolePermission> RolePermissions { get; set; }
        public DbSet<UserToken> UserTokens { get; set; }

        private IDbContextTransaction currentTransaction { get; set; }

        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new RoleEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new UserRoleTypeConfiguration());
            modelBuilder.ApplyConfiguration(new PermissionTypeConfiguration());
            modelBuilder.ApplyConfiguration(new RolePermissionTypeConfiguration());
            modelBuilder.ApplyConfiguration(new UserTokenEntityTypeConfiguration());
        }

        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {   
            int result = await base.SaveChangesAsync().ConfigureAwait(false);            
            return true; 
        }
        
        public async Task BeginTransactionAsync () 
        {
            currentTransaction = currentTransaction ?? await Database.BeginTransactionAsync(IsolationLevel.ReadCommitted).ConfigureAwait(false);
        }

        public async Task CommitTransactionAsync () 
        {
            try 
            {
                await SaveChangesAsync().ConfigureAwait(false);
                currentTransaction?.Commit();
            } catch {
                RollbackTransaction();
                throw;
            } finally {
                if (currentTransaction != null) {
                    currentTransaction.Dispose();
                    currentTransaction = null;
                }
            }
        }

        public void RollbackTransaction () 
        {
            try 
            {
                currentTransaction?.Rollback();
            } finally {
                if (currentTransaction != null) {
                    currentTransaction.Dispose();
                    currentTransaction = null;
                }
            }
        }
    }
}