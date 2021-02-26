using System.Threading;
using System.Threading.Tasks;
using User.Application.Models;
using User.Domain.AggregatesModel.RoleAggregate;
using MediatR;
using User.Application.Abstractions.Query;

namespace User.Application.Queries
{
    public class RolesListQueryHandler : IQueryHandler<RolesListQuery, RoleResponseModel[]>
    {       
        private readonly IRoleRepository _roleRepository;

        public RolesListQueryHandler(IRoleRepository roleRepository)
        {
           _roleRepository = roleRepository;
        }

        public async Task<RoleResponseModel[]> QueryAsync(RolesListQuery query)
        {
            Role[] roleList = await _roleRepository.GetAllAsync();
            return AutoMapper.Mapper.Map<RoleResponseModel[]>(roleList);
        }
    }
}