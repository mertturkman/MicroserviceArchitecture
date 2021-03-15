using System.Threading;
using System.Threading.Tasks;
using User.Application.Models;
using User.Domain.AggregatesModel.RoleAggregate;
using MediatR;
using User.Application.Abstractions.Query;

namespace User.Application.Queries
{
    public class RoleFindByIdQueryHandler : IQueryHandler<RoleFindByIdQuery, RoleResponseModel>
    {
        private readonly IRoleRepository _roleRepository;
        public RoleFindByIdQueryHandler(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task<RoleResponseModel> QueryAsync(RoleFindByIdQuery query)
        {
            Role role = await _roleRepository.FindByIdAsync(query.Id);
            RoleResponseModel roleResponseModel = new RoleResponseModel();

            return roleResponseModel.MapToResponse(role);
        }
    }
}