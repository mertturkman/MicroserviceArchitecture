using System.Data;
using System.Threading;
using System.Threading.Tasks;
using Branch.Domain.AggregatesModel.BranchAggregate;
using Branch.Domain.AggregatesModel.BrandAggregate;
using Branch.Domain.SeedWork;
using Branch.Infrastructure.EntityConfigurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Branch.Infrastructure {
    public class BranchContext : DbContext, IUnitOfWork {
        public const string DEFAULT_SCHEMA = "dbo";
        public DbSet<Branch.Domain.AggregatesModel.BranchAggregate.Branch> Branches { get; set; }
        public DbSet<BranchDetail> BranchDetails { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<BrandDetail> BrandDetails { get; set; }
        private IDbContextTransaction _currentTransaction { get; set; }
        public IDbContextTransaction GetCurrentTransaction => _currentTransaction;

        public BranchContext(DbContextOptions<BranchContext> options) : base(options)
        {
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BranchEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new BranchDetailEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new BrandEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new BrandDetailEntityTypeConfiguration());
        }

        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {                        
            int result = await base.SaveChangesAsync();
            return true; 
        }
        
        public async Task BeginTransactionAsync () 
        {
            _currentTransaction = _currentTransaction ?? await Database.BeginTransactionAsync (IsolationLevel.ReadCommitted);
        }

        public async Task CommitTransactionAsync () 
        {
            try 
            {
                await SaveChangesAsync ();
                _currentTransaction?.Commit ();
            } catch {
                RollbackTransaction ();
                throw;
            } finally {
                if (_currentTransaction != null) {
                    _currentTransaction.Dispose ();
                    _currentTransaction = null;
                }
            }
        }

        public void RollbackTransaction () 
        {
            try 
            {
                _currentTransaction?.Rollback ();
            } finally {
                if (_currentTransaction != null) {
                    _currentTransaction.Dispose ();
                    _currentTransaction = null;
                }
            }
        }
    }
}