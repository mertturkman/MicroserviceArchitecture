using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using User.Application.Abstractions.Command;
using User.Application.Abstractions.Query;

namespace User.API.Controllers
{
    public class BaseController: ControllerBase
    {
        private readonly ICommandDispatcher _commandDispatcher;
        private readonly IQueryDispatcher _queryDispatcher;

        public BaseController(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher)
        {
            _commandDispatcher = commandDispatcher;
            _queryDispatcher = queryDispatcher;
        }

        protected async Task<IActionResult> ExecuteCommandAsync<TCommand>(TCommand command) where TCommand : ICommand
        {
            await _commandDispatcher.HandleAsync(command).ConfigureAwait(false);
            return Ok();
        }

        protected async Task<IActionResult> ExecuteQueryAsync<TQuery, TResult>(TQuery query) where TQuery : IQuery
        {
            TResult result = await _queryDispatcher.HandleAsync<TQuery, TResult>(query).ConfigureAwait(false);
            return Ok(result);
        }
    }
}
