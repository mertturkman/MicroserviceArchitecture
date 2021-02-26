using System;
using System.Collections.Generic;
using User.Domain.AggregatesModel.RoleAggregate;
using User.Domain.SeedWork;

namespace User.Domain.AggregatesModel.PermissionAggregate
{
    public class Permission : Entity, IAggregateRoot
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Code { get; set; }
        public ICollection<RolePermission> RolePermissions { get; set; }

        public Permission() { }

        public Permission(string name, string description, string code)
        {
            if (RolePermissions == null)
                RolePermissions = new List<RolePermission>();

            Name = name;
            Description = description;
            Code = code;
            CreatedTime = DateTime.UtcNow;
        }

        public void SetDefinition(string name, string description, string code)
        {
            Name = name;
            Description = description;
            Code = code;
        }

        public void Delete()
        {
            IsDeleted = true;
        }
    }
}
