using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using User.Domain.AggregatesModel.UserAggregate;
using User.Domain.SeedWork;

namespace User.Infrastructure.Repository {
    public class UserRepository : IUserRepository {
        
        private readonly UserContext _context;
        public IUnitOfWork UnitOfWork {
            get {
                return _context;
            }
        }

        public UserRepository(UserContext context) 
        {
            _context = context;
        }

        public async Task<Domain.AggregatesModel.UserAggregate.User[]> GetAllAsync () {
            return await _context.Users
                .ToArrayAsync().ConfigureAwait(false);
        }

        public async Task<Domain.AggregatesModel.UserAggregate.User> FindByIdAsync(Guid id)
        {
            return await _context.Users
                .SingleAsync(user => user.Id == id)
                .ConfigureAwait(false);
        }

        public async Task<UserRole> FindRoleByIdAsync(Guid id)
        {
            return await _context.UserRoles
                .Include(userRole => userRole.Role)
                .SingleAsync(userRole => userRole.Id == id)
                .ConfigureAwait(false);
        }

        public async Task<UserRole[]> FindRolesByIdAsync (Guid id) {
            return await _context.UserRoles
                .Include(userRole => userRole.Role)
                .Where(userRole => userRole.Id == id)
                .ToArrayAsync()
                .ConfigureAwait(false);
        }

        public void Create(Domain.AggregatesModel.UserAggregate.User user) 
        {
            _context.Entry(user).State = EntityState.Added;
            _context.Entry(user.Address).State = EntityState.Added;   
                
        }

        public void Update(Domain.AggregatesModel.UserAggregate.User user) 
        {
            _context.Entry(user).State = EntityState.Modified;
            _context.Entry(user.Address).State = EntityState.Modified;
        }

        public void AddRole(UserRole userRole)
        {
            _context.Entry(userRole).State = EntityState.Added;
        }

        public void UpdateRole(UserRole userRole)
        {
            _context.Entry(userRole).State = EntityState.Modified;
        }
    }
}