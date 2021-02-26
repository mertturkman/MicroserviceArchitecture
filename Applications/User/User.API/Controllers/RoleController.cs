using Microsoft.AspNetCore.Mvc;
using User.Application.Models;
using System.Threading.Tasks;
using User.Application.Queries;
using User.Application.Commands;
using CrossCutting.Authentication;
using User.Application.Abstractions.Query;
using User.Application.Abstractions.Command;
using Microsoft.AspNetCore.Authorization;

namespace User.API.Controllers
{
    [Route("api/Role")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class RoleController : BaseController
    {
        public RoleController(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher): base(commandDispatcher, queryDispatcher)
        {
        }

        [Route("GetAll")]   
        [HttpGet]
        [PermissionRequirement(CustomClaimType.Permission_RoleGetAll)]
        public async Task<IActionResult> GetAll()
        {
            return await ExecuteQueryAsync<RolesListQuery, RoleResponseModel[]>(new RolesListQuery())
                .ConfigureAwait(false);
        }

        [Route("FindById")]   
        [HttpGet]
        [PermissionRequirement(CustomClaimType.Permission_RoleFindById)]
        public async Task<IActionResult> FindById([FromQuery] RoleFindByIdQuery model)
        {
            return await ExecuteQueryAsync<RoleFindByIdQuery, RoleResponseModel[]>(model)
                .ConfigureAwait(false);
        }

        [Route("Create")]
        [HttpPost]
        [PermissionRequirement(CustomClaimType.Permission_RoleCreate)]
        public async Task<IActionResult> Create([FromBody] CreateRoleCommand model)
        {
            return await ExecuteCommandAsync(model).ConfigureAwait(false);
        }

        [Route("Update")]
        [HttpPut]
        [PermissionRequirement(CustomClaimType.Permission_RoleUpdate)]
        public async Task<IActionResult> Update([FromBody] UpdateRoleCommand model)
        {
            return await ExecuteCommandAsync(model).ConfigureAwait(false);
        }

        [Route("Delete")]
        [HttpDelete]
        [PermissionRequirement(CustomClaimType.Permission_RoleDelete)]
        public async Task<IActionResult> Delete([FromBody] DeletePermissionCommand model)
        {
            return await ExecuteCommandAsync(model).ConfigureAwait(false);
        }

        [Route("AddPermissionToRole")]
        [HttpPost]
        [PermissionRequirement(CustomClaimType.Permission_AddPermissionToRole)]
        public async Task<IActionResult> AddPermissionToRole([FromBody] AddPermissionToRoleCommand model)
        {
            return await ExecuteCommandAsync(model).ConfigureAwait(false);
        }

        [Route("DeletePermissionFromRole")]
        [HttpDelete]
        [PermissionRequirement(CustomClaimType.Permission_DeletePermissionFromRole)]
        public async Task<IActionResult> DeletePermissionFromRole([FromBody] DeletePermissionFromRoleCommand model)
        {
            return await ExecuteCommandAsync(model).ConfigureAwait(false);
        }
    }
}