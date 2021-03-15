using System;
using System.Collections.Generic;
using User.Domain.AggregatesModel.RoleAggregate;

namespace User.Application.Models
{
    public class RoleResponseModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public RoleResponseModel MapToResponse(Role role)
        {
            Id = role.Id;
            Name = role.Name;
            Description = role.Description;

            return this;
        }

        public RoleResponseModel[] MapToResponse(Role[] roles)
        {
            List<RoleResponseModel> roleResponseModels = new List<RoleResponseModel>();

            foreach (var roleItem in roles)
            {
                RoleResponseModel roleResponseModel = new RoleResponseModel();
                roleResponseModel.Id = roleItem.Id;
                roleResponseModel.Name = roleItem.Name;
                roleResponseModel.Description = roleItem.Description;

                roleResponseModels.Add(roleResponseModel);
            }

            return roleResponseModels.ToArray();
        }
    }
}