using CrossCutting.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using User.Application.Abstractions.Command;
using User.Application.Abstractions.Query;
using User.Application.Commands;
using User.Application.Models;
using User.Application.Queries;

namespace User.API.Controllers
{
    [Route("api/Permission")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class PermissionController : BaseController
    {
        public PermissionController(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher) : base(commandDispatcher, queryDispatcher)
        {
        }

        [Route("GetAll")]
        [HttpGet]
        [PermissionRequirement(CustomClaimType.Permission_PermissionGetAll)]
        public async Task<IActionResult> GetAll()
        {
            return await ExecuteQueryAsync<PermissionsListQuery, PermissionResponseModel[]>(new PermissionsListQuery())
                .ConfigureAwait(false);
        }

        [Route("FindById")]
        [HttpGet]
        [PermissionRequirement(CustomClaimType.Permission_PermissionFindById)]
        public async Task<IActionResult> FindById([FromQuery] PermissionFindByIdQuery model)
        {
            return await ExecuteQueryAsync<PermissionFindByIdQuery, PermissionResponseModel>(model)
                .ConfigureAwait(false);
        }

        [Route("Create")]
        [HttpPost]
        [PermissionRequirement(CustomClaimType.Permission_PermissionCreate)]
        public async Task<IActionResult> Create([FromBody] CreatePermissionCommand model)
        {
            return await ExecuteCommandAsync(model).ConfigureAwait(false);
        }

        [Route("Update")]
        [HttpPut]
        [PermissionRequirement(CustomClaimType.Permission_PermissionUpdate)]
        public async Task<IActionResult> Update([FromBody] UpdatePermissionCommand model)
        {
            return await ExecuteCommandAsync(model).ConfigureAwait(false);
        }

        [Route("Delete")]
        [HttpDelete]
        [PermissionRequirement(CustomClaimType.Permission_PermissionDelete)]
        public async Task<IActionResult> Delete([FromBody] DeletePermissionCommand model)
        {
            return await ExecuteCommandAsync(model).ConfigureAwait(false);
        }
    }
}
