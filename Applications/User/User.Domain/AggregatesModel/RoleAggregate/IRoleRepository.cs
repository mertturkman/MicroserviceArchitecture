using System;
using System.Threading.Tasks;
using User.Domain.SeedWork;

namespace User.Domain.AggregatesModel.RoleAggregate {
    public interface IRoleRepository : IRepository<Role> {
        Task<Role[]> GetAllAsync();
        Task<Role> FindByIdAsync(Guid id);
        Task<Role> FindByNameAsync(string name);
        void Create(Role role);
        void Update(Role role);
        Task<RolePermission> FindPermissionByIdAsync(Guid id);
        Task<RolePermission[]> FindPermissionsByIdAsync(Guid id);
        void AddPermission(RolePermission rolePermission);
        void UpdatePermission(RolePermission rolePermission);
    }
}