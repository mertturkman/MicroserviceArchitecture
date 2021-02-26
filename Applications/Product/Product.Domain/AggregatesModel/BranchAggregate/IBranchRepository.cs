using System;
using System.Threading.Tasks;
using Product.Domain.SeedWork;

namespace Product.Domain.AggregatesModel.BranchAggregate {
    public interface IBranchRepository : IRepository<Branch> {
        Task<Branch[]> GetAllAsync();
        Task<Branch> FindByIdAsync(Guid id);
        void Create(Branch branch);
        void Update(Branch branch);
    }
}