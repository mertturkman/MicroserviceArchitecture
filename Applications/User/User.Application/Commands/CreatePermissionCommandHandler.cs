using System.Threading.Tasks;
using User.Domain.AggregatesModel.PermissionAggregate;
using User.Application.Abstractions.Command;
using User.Domain.Exceptions;

namespace User.Application.Commands
{
    public class CreatePermissionCommandHandler : ICommandHandler<CreatePermissionCommand>
    {
        private readonly IPermissionRepository _permissionRepository;

        public CreatePermissionCommandHandler(IPermissionRepository permissionRepository)
        {
            _permissionRepository = permissionRepository;
        }

        public async Task ExecuteAsync(CreatePermissionCommand command)
        {
            bool isExist = await _permissionRepository.IsExistByNameAsync(command.Name);
            
            if (!isExist) 
            {
                Permission permission = new Permission(command.Name, command.Description, command.Code);
                _permissionRepository.Create(permission);
            }
            else
            {
                throw new ConflictException();
            }
        }
    }
}
