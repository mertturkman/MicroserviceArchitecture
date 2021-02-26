using System;
using System.Threading.Tasks;
using Branch.Domain.SeedWork;

namespace Branch.Domain.AggregatesModel.BranchAggregate {
    public interface IBranchRepository : IRepository<Branch> {
        Task<Branch[]> GetAllAsync();
        Task<Branch> FindByIdAsync(Guid id);
        void Create(Branch branch);
        void Update(Branch branch);
    }
}