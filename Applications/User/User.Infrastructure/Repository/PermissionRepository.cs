using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using User.Domain.AggregatesModel.PermissionAggregate;
using User.Domain.SeedWork;

namespace User.Infrastructure.Repository
{
    public class PermissionRepository : IPermissionRepository
    {
        private readonly UserContext _context;
        public IUnitOfWork UnitOfWork
        {
            get
            {
                return _context;
            }
        }

        public PermissionRepository(UserContext context)
        {
            _context = context;
        }

        public async Task<Permission[]> GetAllAsync()
        {
            return await _context.Permissions
                .ToArrayAsync().ConfigureAwait(false);
        }

        public async Task<Permission> FindByIdAsync(Guid id)
        {
            return await _context.Permissions
                .SingleOrDefaultAsync(permission => permission.Id == id)
                .ConfigureAwait(false);
        }

        public async Task<Permission> FindByNameAsync(string name)
        {
            return await _context.Permissions
                .SingleOrDefaultAsync(permission => permission.Name == name)
                .ConfigureAwait(false);
        }

        public async Task<bool> IsExistByIdAsync(Guid id)
        {
            return await _context.Permissions
                .AnyAsync(permission => permission.Id == id)
                .ConfigureAwait(false);
        }

        public async Task<bool> IsExistByNameAsync(string name)
        {
            return await _context.Permissions
                .AnyAsync(permission => permission.Name == name)
                .ConfigureAwait(false);
        }

        public void Create(Permission permission)
        {
            _context.Entry(permission).State = EntityState.Added;
        }

        public void Update(Permission permission)
        {
            _context.Entry(permission).State = EntityState.Modified;
        }

    }
}
