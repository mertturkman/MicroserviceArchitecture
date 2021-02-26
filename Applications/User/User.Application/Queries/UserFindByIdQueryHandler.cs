using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using User.Application.Commands;
using User.Application.Models;
using User.Domain.AggregatesModel.UserAggregate;
using MediatR;
using User.Application.Abstractions.Query;

namespace User.Application.Queries {
    public class UserFindByIdQueryHandler : IQueryHandler<UserFindByIdQuery, UserResponseModel> {
        private readonly IUserRepository _userRepository;

        public UserFindByIdQueryHandler (IUserRepository userRepository) {
            _userRepository = userRepository;
        }

        public async Task<UserResponseModel> QueryAsync(UserFindByIdQuery query)
        {
            Domain.AggregatesModel.UserAggregate.User user = await _userRepository.FindByIdAsync(query.Id);
            return AutoMapper.Mapper.Map<UserResponseModel>(user);
        }
    }
}