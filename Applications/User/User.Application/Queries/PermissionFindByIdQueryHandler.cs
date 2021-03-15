using System.Threading.Tasks;
using User.Application.Abstractions.Query;
using User.Application.Models;
using User.Domain.AggregatesModel.PermissionAggregate;

namespace User.Application.Queries
{
    public class PermissionFindByIdQueryHandler : IQueryHandler<PermissionFindByIdQuery, PermissionResponseModel>
    {
        private readonly IPermissionRepository _permissionRepository;
        public PermissionFindByIdQueryHandler(IPermissionRepository permissionRepository)
        {
            _permissionRepository = permissionRepository;
        }

        public async Task<PermissionResponseModel> QueryAsync(PermissionFindByIdQuery query)
        {
            Permission permission = await _permissionRepository.FindByIdAsync(query.Id);
            PermissionResponseModel permissionResponseModel = new PermissionResponseModel();

            return permissionResponseModel.MapToResponse(permission);
        }
    }
}
