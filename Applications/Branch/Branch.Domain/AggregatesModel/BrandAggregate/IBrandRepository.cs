using System;
using System.Threading.Tasks;
using Branch.Domain.SeedWork;

namespace Branch.Domain.AggregatesModel.BrandAggregate {
    public interface IBrandRepository : IRepository<Brand> {
        Task<Brand[]> GetAllAsync();
        Task<Brand> FindByIdAsync(Guid id);
        void Create(Brand product);
        void Update(Brand product);
    }
}