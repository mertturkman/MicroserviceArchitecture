using System;
using System.Threading.Tasks;
using Product.Domain.SeedWork;

namespace Product.Domain.AggregatesModel.ProductAggregate {
    public interface IProductRepository : IRepository<Product> {
        Task<Product[]> GetAllAsync();
        Task<Product> FindByIdAsync(Guid id);
        void Create(Product product);
        void Update(Product product);
    }
}