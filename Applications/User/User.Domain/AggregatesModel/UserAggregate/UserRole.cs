using System;
using User.Domain.AggregatesModel.RoleAggregate;
using User.Domain.SeedWork;

namespace User.Domain.AggregatesModel.UserAggregate {
    public class UserRole : Entity {
        public Guid UserId { get; set; }
        public User User { get; set; }
        public Guid RoleId { get; set; }
        public Role Role { get; set; }

        public UserRole () { }

        public UserRole (Guid userId, Guid roleId) {
            UserId = userId;
            RoleId = roleId;
            CreatedTime = DateTime.UtcNow;
        }

        public UserRole (User user, Role role) {
            User = user;
            Role = role;
            CreatedTime = DateTime.UtcNow;
        }

        public void Delete()
        {
            IsDeleted = true;
        }
    }
}