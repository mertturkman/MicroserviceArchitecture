using System;
using System.Collections.Generic;
using System.Text;
using User.Domain.AggregatesModel.PermissionAggregate;
using User.Domain.SeedWork;

namespace User.Domain.AggregatesModel.RoleAggregate
{
    public class RolePermission : Entity
    {
        public Guid RoleId { get; set; }
        public Role Role { get; set; }
        public Guid PermissionId { get; set; }
        public Permission Permission { get; set; }

        public RolePermission() { }

        public RolePermission(Guid permissionId, Guid roleId)
        {
            RoleId = roleId;
            PermissionId = permissionId;
            CreatedTime = DateTime.UtcNow;
        }

        public RolePermission(Permission permission, Role role)
        {
            Permission = permission;
            Role = role;
            CreatedTime = DateTime.UtcNow;
        }
        
        public void Delete()
        {
            IsDeleted = true;
        }
    }
}
