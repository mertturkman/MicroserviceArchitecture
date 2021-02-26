using System;
using System.Collections.Generic;
using System.Text;
using User.Domain.AggregatesModel.UserAggregate;

namespace User.Application.Models
{
    public class UserRoleResponseModel
    {
        public UserRoleModel[] UserRoles { get; set; }

        public UserRoleResponseModel MapToResponse(UserRole[] userRoleEntities)
        {
            List<UserRoleModel> rolePermissionModels = new List<UserRoleModel>();

            foreach(UserRole userRoleEntityItem in userRoleEntities)
            {
                UserRoleModel rolePermissionModel = new UserRoleModel
                {
                    Id = userRoleEntityItem.Id,
                    UserId = userRoleEntityItem.UserId,
                    RoleId = userRoleEntityItem.RoleId,
                    RoleName = userRoleEntityItem.Role.Name
                };
                rolePermissionModels.Add(rolePermissionModel);
            }
            UserRoles = rolePermissionModels.ToArray();

            return this;
        }
    }

    public class UserRoleModel
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid RoleId { get; set; }
        public string RoleName { get; set; }
    }
}
