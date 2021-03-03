using System;
using System.Threading.Tasks;
using User.Domain.SeedWork;

namespace User.Domain.AggregatesModel.PermissionAggregate
{
    public interface IPermissionRepository : IRepository<Permission>
    {
        Task<Permission[]> GetAllAsync();
        Task<Permission> FindByIdAsync(Guid id);
        Task<Permission> FindByNameAsync(string name);
        Task<bool> IsExistByIdAsync(Guid id);
        Task<bool> IsExistByNameAsync(string name);
        void Create(Permission permission);
        void Update(Permission permission);
    }
}
