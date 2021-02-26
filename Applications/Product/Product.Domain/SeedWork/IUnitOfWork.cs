using System;
using System.Threading;
using System.Threading.Tasks;

namespace Product.Domain.SeedWork {
    public interface IUnitOfWork : IDisposable {
        Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default(CancellationToken));
        Task BeginTransactionAsync();
        Task CommitTransactionAsync();
        void RollbackTransaction();
    }
}