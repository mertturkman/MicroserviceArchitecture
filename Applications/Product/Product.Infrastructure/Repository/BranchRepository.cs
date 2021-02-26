using System;
using System.Linq;
using System.Threading.Tasks;
using Product.Domain.AggregatesModel.BranchAggregate;
using Product.Domain.SeedWork;
using Microsoft.EntityFrameworkCore;

namespace Product.Infrastructure.Repository 
{
    public class BranchRepository : IBranchRepository 
    {
        private readonly ProductContext _context;
        public IUnitOfWork UnitOfWork 
        {
            get 
            {
                return _context;
            }
        }

        public BranchRepository(ProductContext context) 
        {
            _context = context;
        }

        public async Task<Branch[]> GetAllAsync() 
        {
            return await _context.Branches.ToArrayAsync ();
        }

        public async Task<Branch> FindByIdAsync(Guid id) 
        {
            return await _context.Branches.Where (branch => branch.Id == id).FirstOrDefaultAsync();
        }

        public void Create(Branch branch) 
        {
            _context.Branches.Add(branch);
        }

        public void Update(Branch branch) 
        {
            _context.Branches.Update(branch);
        }
    }
}