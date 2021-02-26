using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using User.Application.Abstractions.Query;
using User.Application.Models;
using User.Domain.AggregatesModel.UserAggregate;

namespace User.Application.Queries
{
    public class RoleListFindByUserIdQueryHandler : IQueryHandler<RoleListFindByUserIdQuery, UserRoleResponseModel>
    {

        public readonly IUserRepository _userRepository;

        public RoleListFindByUserIdQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserRoleResponseModel> QueryAsync(RoleListFindByUserIdQuery query)
        {
            UserRole[] userRoleEntities = await _userRepository.FindRolesByIdAsync(query.UserId);
            UserRoleResponseModel userRoleResponseModel = new UserRoleResponseModel();

            return userRoleResponseModel.MapToResponse(userRoleEntities);
        }
    }
}
