using System;
using System.Linq;
using System.Threading.Tasks;
using Branch.Domain.AggregatesModel.BranchAggregate;
using Branch.Domain.SeedWork;
using Microsoft.EntityFrameworkCore;

namespace Branch.Infrastructure.Repository 
{
    public class BranchRepository : IBranchRepository 
    {
        private readonly BranchContext _context;
        public IUnitOfWork UnitOfWork 
        {
            get 
            {
                return _context;
            }
        }

        public BranchRepository(BranchContext context) 
        {
            _context = context;
        }

        public async Task<Branch.Domain.AggregatesModel.BranchAggregate.Branch[]> GetAllAsync() 
        {
            return await _context.Branches.ToArrayAsync();
        }

        public async Task<Branch.Domain.AggregatesModel.BranchAggregate.Branch> FindByIdAsync(Guid id) 
        {
            return await _context.Branches.Where(branch => branch.Id == id).FirstOrDefaultAsync();
        }

        public void Create(Branch.Domain.AggregatesModel.BranchAggregate.Branch branch) 
        {
            _context.Branches.Add(branch);
        }

        public void Update(Branch.Domain.AggregatesModel.BranchAggregate.Branch branch) 
        {
            _context.Branches.Update(branch);
        }
    }
}