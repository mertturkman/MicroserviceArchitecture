using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace User.Application.Abstractions.Command
{
    public interface ICommandDispatcher
    {
        Task HandleAsync<TCommand>(TCommand command) where TCommand : ICommand;
    }
}
