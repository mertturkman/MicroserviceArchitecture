using System;
using System.Threading.Tasks;
using User.Domain.SeedWork;

namespace User.Domain.AggregatesModel.UserAggregate {
    public interface IUserRepository : IRepository<User> {
        Task<User[]> GetAllAsync();
        Task<User> FindByIdAsync(Guid id);
        Task<UserRole> FindRoleByIdAsync(Guid id);
        Task<UserRole[]> FindRolesByIdAsync(Guid id);
        void Create(User user);
        void Update(User user);
        void AddRole(UserRole userRole);
        void UpdateRole(UserRole userRole);
    }
}