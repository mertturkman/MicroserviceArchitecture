using System;
using System.Threading.Tasks;
using User.Domain.SeedWork;

namespace User.Domain.AggregatesModel.PermissionAggregate
{
    public interface IPermissionRepository : IRepository<Permission>
    {
        Task<Permission[]> GetAllAsync();
        Task<Permission> FindByIdAsync(Guid id);
        void Create(Permission permission);
        void Update(Permission permission);
    }
}
