using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using User.Application.Abstractions.Query;
using User.Application.Models;
using User.Domain.AggregatesModel.RoleAggregate;

namespace User.Application.Queries
{
    public class PermissionListFindByRoleIdQueryHandler : IQueryHandler<PermissionListFindByRoleIdQuery, RolePermissionsViewModel>
    {
        public readonly IRoleRepository _roleRepository;

        public PermissionListFindByRoleIdQueryHandler(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task<RolePermissionsViewModel> QueryAsync(PermissionListFindByRoleIdQuery query)
        {
            RolePermission[] rolePermissionEntities = await _roleRepository.FindPermissionsByIdAsync(query.RoleId);
            RolePermissionsViewModel rolePermissionsViewModel = new RolePermissionsViewModel();

            return rolePermissionsViewModel.MapToResponse(rolePermissionEntities);
        }
    }
}
