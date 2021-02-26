using System;
using System.Linq;
using System.Threading.Tasks;
using Branch.Domain.AggregatesModel.BrandAggregate;
using Branch.Domain.SeedWork;
using Microsoft.EntityFrameworkCore;

namespace Branch.Infrastructure.Repository 
{
    public class BrandRepository : IBrandRepository 
    {
        private readonly BranchContext _context;
        public IUnitOfWork UnitOfWork 
        {
            get 
            {
                return _context;
            }
        }

        public BrandRepository(BranchContext context) 
        {
            _context = context;
        }

        public async Task<Brand[]> GetAllAsync() 
        {
            return await _context.Brands.ToArrayAsync();
        }

        public async Task<Brand> FindByIdAsync(Guid id) 
        {
            return await _context.Brands.Where(product => product.Id == id).FirstOrDefaultAsync();
        }

        public void Create(Brand brand) 
        {
            _context.Brands.Add(brand);
        }

        public void Update(Brand brand) 
        {
            _context.Brands.Update(brand);
        }
    }
}