using System;
using System.Linq;
using System.Threading.Tasks;
using User.Domain.AggregatesModel.RoleAggregate;
using User.Domain.SeedWork;
using Microsoft.EntityFrameworkCore;

namespace User.Infrastructure.Repository 
{
    public class RoleRepository : IRoleRepository 
    {
        private readonly UserContext _context;
        public IUnitOfWork UnitOfWork 
        {
            get 
            {
                return _context;
            }
        }

        public RoleRepository(UserContext context) 
        {
            _context = context;
        }

        public async Task<Role[]> GetAllAsync() 
        {
            return await _context.Roles
                .ToArrayAsync().ConfigureAwait(false);
        }

        public async Task<Role> FindByIdAsync(Guid id) 
        {
            return await _context.Roles
                .SingleOrDefaultAsync(role => role.Id == id)
                .ConfigureAwait(false);
        }

        public async Task<Role> FindByNameAsync(string name) 
        {   
            return await _context.Roles
                .SingleOrDefaultAsync(role => role.Name == name)
                .ConfigureAwait(false);
        }

        public async Task<RolePermission> FindPermissionByIdAsync(Guid id)
        {
            return await _context.RolePermissions
                .Include(rolePermission => rolePermission.Permission)
                .SingleOrDefaultAsync(rolePermission => rolePermission.Id == id)
                .ConfigureAwait(false);
        }

        public async Task<bool> IsExistByIdAsync(Guid id)
        {
            return await _context.Roles
                .AnyAsync(permission => permission.Id == id)
                .ConfigureAwait(false);
        }

        public async Task<bool> IsExistByNameAsync(string name)
        {
            return await _context.Roles
                .AnyAsync(permission => permission.Name == name)
                .ConfigureAwait(false);
        }

        public async Task<bool> IsExistPermissionByIdAsync(Guid roleId, Guid permissionId)
        {
            return await _context.RolePermissions
                .AnyAsync(rolePermission => rolePermission.PermissionId == permissionId && rolePermission.RoleId == roleId)
                .ConfigureAwait(false);
        }

        public void Create(Role role) 
        {
            _context.Entry(role).State = EntityState.Added;
        }

        public void Update(Role role) 
        {
            _context.Entry(role).State = EntityState.Modified;
        }

        public void AddPermission(RolePermission rolePermission)
        {
            _context.Entry(rolePermission).State = EntityState.Added;
        }

        public void UpdatePermission(RolePermission rolePermission)
        {
            _context.Entry(rolePermission).State = EntityState.Modified;
        }

        public async Task<RolePermission[]> FindPermissionsByIdAsync(Guid id)
        {
            return await _context.RolePermissions
                .Include(rolePermission => rolePermission.Permission)
                .Where(rolePermission => rolePermission.Id == id)
                .ToArrayAsync()
                .ConfigureAwait(false);
        }
    }
}