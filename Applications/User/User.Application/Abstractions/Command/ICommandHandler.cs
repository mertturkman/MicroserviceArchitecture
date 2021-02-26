using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace User.Application.Abstractions.Command
{
    public interface ICommandHandler<TCommand> where TCommand : ICommand
    {
        Task ExecuteAsync(TCommand command);
    }
}
