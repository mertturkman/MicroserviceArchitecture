using System;
using System.Collections.Generic;
using System.Text;
using User.Domain.AggregatesModel.RoleAggregate;

namespace User.Application.Models
{
    public class RolePermissionsViewModel
    {
        public RolePermissionModel[] RolePermissions { get; set;}

        public RolePermissionsViewModel MapToResponse(RolePermission[] rolePermissionEntities)
        {
            List<RolePermissionModel> rolePermissionModels = new List<RolePermissionModel>();

            foreach (RolePermission rolePermissionEntityItem in rolePermissionEntities)
            {
                RolePermissionModel rolePermissionModel = new RolePermissionModel
                {
                    Id = rolePermissionEntityItem.Id,
                    PermissionId = rolePermissionEntityItem.Permission.Id,
                    RoleId = rolePermissionEntityItem.RoleId,
                    PermissionName = rolePermissionEntityItem.Permission.Name
                };
                rolePermissionModels.Add(rolePermissionModel);
            }
            RolePermissions = rolePermissionModels.ToArray();

            return this;
        }
    }

    public class RolePermissionModel
    {
        public Guid Id { get; set; }
        public Guid RoleId { get; set; }
        public Guid PermissionId { get; set; }
        public string PermissionName { get; set; }
    }
}
