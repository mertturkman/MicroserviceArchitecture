using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using User.Application.Models;
using User.Domain.AggregatesModel.UserAggregate;
using MediatR;
using User.Application.Abstractions.Query;

namespace User.Application.Queries {
    public class UsersListQueryHandler : IQueryHandler<UsersListQuery, UserResponseModel[]> 
    {
        private readonly IUserRepository _userRepository;

        public UsersListQueryHandler(IUserRepository userRepository) 
        {
            _userRepository = userRepository;
        }

        public async Task<UserResponseModel[]> QueryAsync(UsersListQuery query)
        {
            Domain.AggregatesModel.UserAggregate.User[] userList = await _userRepository.GetAllAsync();
            UserResponseModel userResponseModel = new UserResponseModel();

            return userResponseModel.MapToResponse(userList);
        }
    }
}