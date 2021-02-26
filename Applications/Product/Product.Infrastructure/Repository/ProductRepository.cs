using System;
using System.Linq;
using System.Threading.Tasks;
using Product.Domain.AggregatesModel.ProductAggregate;
using Product.Domain.SeedWork;
using Microsoft.EntityFrameworkCore;

namespace Product.Infrastructure.Repository 
{
    public class ProductRepository : IProductRepository 
    {
        private readonly ProductContext _context;
        public IUnitOfWork UnitOfWork 
        {
            get 
            {
                return _context;
            }
        }

        public ProductRepository(ProductContext context) 
        {
            _context = context;
        }

        public async Task<Product.Domain.AggregatesModel.ProductAggregate.Product[]> GetAllAsync() 
        {
            return await _context.Products.ToArrayAsync ();
        }

        public async Task<Product.Domain.AggregatesModel.ProductAggregate.Product> FindByIdAsync(Guid id) 
        {
            return await _context.Products.Where (product => product.Id == id).FirstOrDefaultAsync ();
        }

        public void Create(Product.Domain.AggregatesModel.ProductAggregate.Product product) 
        {
            _context.Products.Add(product);
        }

        public void Update(Product.Domain.AggregatesModel.ProductAggregate.Product product) 
        {
            _context.Products.Update(product);
        }
    }
}