using System.Threading.Tasks;
using User.Application.Commands;
using User.Application.Models;
using User.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using CrossCutting.Authentication;
using User.Application.Abstractions.Command;
using User.Application.Abstractions.Query;
using Microsoft.AspNetCore.Authorization;
using System.Net;

namespace User.API.Controllers
{
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class UserController : BaseController
    {
        public UserController(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher): base(commandDispatcher, queryDispatcher)
        {
        }

        [Route("GetAll")]
        [HttpGet]
        [PermissionRequirement(CustomClaimType.Permission_UserGetAll)]
        public async Task<IActionResult> GetAll()
        {
            return await ExecuteQueryAsync<UsersListQuery, UserResponseModel[]>(new UsersListQuery())
                .ConfigureAwait(false);
        }

        [Route("FindById")]   
        [HttpGet]
        [PermissionRequirement(CustomClaimType.Permission_UserFindById)]
        public async Task<IActionResult> FindById([FromQuery] UserFindByIdQuery model)
        {
            return await ExecuteQueryAsync<UserFindByIdQuery, UserResponseModel>(model)
                .ConfigureAwait(false);
        }

        [Route("Create")]
        [HttpPost]
        [PermissionRequirement(CustomClaimType.Permission_UserCreate)]
        public async Task<IActionResult> Create([FromBody] CreateUserCommand model)
        {
            return await ExecuteCommandAsync(model).ConfigureAwait(false);
        }

        [Route("Update")]
        [HttpPut]
        [PermissionRequirement(CustomClaimType.Permission_UserUpdate)]
        public async Task<IActionResult> Update([FromBody] UpdateUserCommand model)
        {
            return await ExecuteCommandAsync(model).ConfigureAwait(false);
        }

        [Route("Delete")]
        [HttpDelete]
        [PermissionRequirement(CustomClaimType.Permission_UserDelete)]
        public async Task<IActionResult> Delete([FromBody] DeleteUserCommand model)
        {
            return await ExecuteCommandAsync(model).ConfigureAwait(false);
        }

        [Route("Register")]
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterCommand model) 
        {
            return await ExecuteCommandAsync(model).ConfigureAwait(false);
        }

        [Route("AddRoleToUser")]
        [HttpPost]
        [PermissionRequirement(CustomClaimType.Permission_AddRoleToUser)]
        public async Task<IActionResult> AddRoleToUser([FromBody] AddRoleToUserCommand model)
        {
            return await ExecuteCommandAsync(model).ConfigureAwait(false);
        }

        [Route("DeleteRoleFromUser")]
        [HttpDelete]
        [PermissionRequirement(CustomClaimType.Permission_DeleteRoleFromUser)]
        public async Task<IActionResult> DeleteRoleFromUser([FromBody] DeleteRoleFromUserCommand model)
        {
            return await ExecuteCommandAsync(model).ConfigureAwait(false);
        }

        [Route("ChangePassword")]
        [HttpPut]
        [PermissionRequirement(CustomClaimType.Permission_ChangePassword)]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordCommand model)
        {
            return await ExecuteCommandAsync(model).ConfigureAwait(false);
        }
    }
}