using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using User.Domain.AggregatesModel.UserAggregate;
using User.Domain.SeedWork;

namespace User.Infrastructure.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly UserContext _context;

        public IUnitOfWork UnitOfWork
        {
            get { return _context; }
        }

        public UserRepository(UserContext context)
        {
            _context = context;
        }

        public async Task<Domain.AggregatesModel.UserAggregate.User[]> GetAllAsync()
        {
            return await _context.Users
                .ToArrayAsync().ConfigureAwait(false);
        }

        public async Task<Domain.AggregatesModel.UserAggregate.User> FindByIdAsync(Guid id)
        {
            return await _context.Users
                .SingleOrDefaultAsync(user => user.Id == id)
                .ConfigureAwait(false);
        }

        public async Task<Domain.AggregatesModel.UserAggregate.User> FindByMailAsync(string mail)
        {
            return await _context.Users
                .SingleOrDefaultAsync(user => user.Mail == mail)
                .ConfigureAwait(false);
        }

        public async Task<UserRole> FindRoleByIdAsync(Guid id)
        {
            return await _context.UserRoles
                .Include(userRole => userRole.Role)
                .SingleOrDefaultAsync(userRole => userRole.Id == id)
                .ConfigureAwait(false);
        }

        public async Task<UserRole[]> FindRolesByIdAsync(Guid id)
        {
            return await _context.UserRoles
                .Include(userRole => userRole.Role)
                .Where(userRole => userRole.Id == id)
                .ToArrayAsync()
                .ConfigureAwait(false);
        }

        public async Task<bool> IsExistByIdAsync(Guid id)
        {
            return await _context.Users
                .AnyAsync(user => user.Id == id)
                .ConfigureAwait(false);
        }

        public async Task<bool> IsExistByUsernameAndMailAsync(string username, string mail)
        {
            return await _context.Users
                .AnyAsync(user => user.Username == username && user.Mail == mail)
                .ConfigureAwait(false);
        }

        public async Task<bool> IsExistRoleByIdAsync(Guid userId, Guid roleId)
        {
            return await _context.UserRoles
                .AnyAsync(userRole => userRole.UserId == userId && userRole.RoleId == roleId)
                .ConfigureAwait(false);
        }

        public async Task<bool> IsTokenValidationAsync(Guid userId, string token, int tokenTimeoutMinute)
        {
            UserToken userToken = await _context.UserTokens
                .FirstOrDefaultAsync(userToken => userToken.UserId == userId
                                       && userToken.Token == token
                                       && !userToken.IsUsing)
                .ConfigureAwait(false);
            
            return userToken != null && DateTime.UtcNow < userToken.CreatedTime.Add(TimeSpan.FromMinutes(tokenTimeoutMinute));
        }

        public async Task<UserToken> FindUserTokenByUserIdAndTokenAsync(Guid userId, string token)
        {
            return await _context.UserTokens
                .FirstOrDefaultAsync(userToken => userToken.UserId == userId
                                       && userToken.Token == token
                                       && !userToken.IsUsing)
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
            
            if (user.Address != null)
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

        public void CreateToken(UserToken userToken)
        {
            _context.Entry(userToken).State = EntityState.Added;
        }

        public void UpdateToken(UserToken userToken)
        {
            _context.Entry(userToken).State = EntityState.Modified;
        }
    }
}