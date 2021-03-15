using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using User.Application.Abstractions.Query;
using User.Application.Models;
using User.Domain.AggregatesModel.PermissionAggregate;

namespace User.Application.Queries
{
    public class PermissionsListQueryHandler : IQueryHandler<PermissionsListQuery, PermissionResponseModel[]>
    {
        private readonly IPermissionRepository _permissionRepository;

        public PermissionsListQueryHandler(IPermissionRepository permissionRepository)
        {
            _permissionRepository = permissionRepository;
        }

        public async Task<PermissionResponseModel[]> QueryAsync(PermissionsListQuery query)
        {
            Permission[] permissionList = await _permissionRepository.GetAllAsync();
            PermissionResponseModel permissionResponseModel = new PermissionResponseModel();

            return permissionResponseModel.MapToResponse(permissionList);
        }
    }
}
