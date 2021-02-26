using System;
using System.Collections.Generic;
using User.Domain.AggregatesModel.UserAggregate;
using User.Domain.SeedWork;

namespace User.Domain.AggregatesModel.RoleAggregate
{
    public class Role:Entity, IAggregateRoot
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }
        public ICollection<RolePermission> RolePermissions { get; set; }

        public Role() {}

        public Role(string name, string description) 
        {
            if(UserRoles == null)
                UserRoles = new List<UserRole>();

            if (RolePermissions == null)
                RolePermissions = new List<RolePermission>();

            Name = name;
            Description = description;
            CreatedTime = DateTime.UtcNow;
        }

        public void SetDefinition(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public void Delete()
        {
            IsDeleted = true;
        }
    }
}