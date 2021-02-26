using System.Data;
using System.Threading;
using System.Threading.Tasks;
using Product.Domain.AggregatesModel.BranchAggregate;
using Product.Domain.AggregatesModel.ProductAggregate;
using Product.Domain.SeedWork;
using Product.Infrastructure.EntityConfigurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Product.Infrastructure {
    public class ProductContext : DbContext, IUnitOfWork {
        public const string DEFAULT_SCHEMA = "dbo";
        public DbSet<Product.Domain.AggregatesModel.ProductAggregate.Product> Products { get; set; }
        public DbSet<ProductDetail> ProductDetails { get; set; }
        public DbSet<Branch> Branches { get; set; }
        private IDbContextTransaction _currentTransaction { get; set; }
        public IDbContextTransaction GetCurrentTransaction => _currentTransaction;

        public ProductContext(DbContextOptions<ProductContext> options) : base(options)
        {
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ProductDetailEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new BranchEntityTypeConfiguration());
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