using AutoMapper.Attributes;
using System;
using System.Collections.Generic;
using System.Text;
using User.Domain.AggregatesModel.PermissionAggregate;

namespace User.Application.Models
{
    public class PermissionResponseModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public PermissionResponseModel MapToResponse(Permission permission)
        {
            Id = permission.Id;
            Name = permission.Name;
            Description = permission.Description;

            return this;
        }

        public PermissionResponseModel[] MapToResponse(Permission[] permissions)
        {
            List<PermissionResponseModel> permissionResponseModels = new List<PermissionResponseModel>();

            foreach(var permissionItem in permissions)
            {
                PermissionResponseModel permissionResponseModel = new PermissionResponseModel();
                permissionResponseModel.Id = permissionItem.Id;
                permissionResponseModel.Name = permissionItem.Name;
                permissionResponseModel.Description = permissionItem.Description;

                permissionResponseModels.Add(permissionResponseModel);
            }

            return permissionResponseModels.ToArray();
        }

    }
}
