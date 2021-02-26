using System.Threading.Tasks;
using User.Domain.AggregatesModel.UserAggregate;
using User.Domain.AggregatesModel.RoleAggregate;
using User.Application.Utility;
using User.Application.Abstractions.Command;

namespace User.Application.Commands {
    public class RegisterCommandHandler : ICommandHandler<RegisterCommand> 
    {
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;

        public RegisterCommandHandler(IUserRepository userRepository, IRoleRepository roleRepository){
            _userRepository = userRepository;
            _roleRepository = roleRepository;
        }

        public async Task ExecuteAsync(RegisterCommand command)
        {
            Role role = await _roleRepository.FindByNameAsync(RoleName.User);
            Address address = new Address(command.Street, command.City, command.State, command.Country, command.ZipCode);
            Domain.AggregatesModel.UserAggregate.User user = new Domain.AggregatesModel.UserAggregate.User(command.Name,
                command.Surname, command.Username, PasswordHasher.CryptoSHA256(command.Password), command.Mail, address);
            UserRole userRole = new UserRole(user, role);

            _userRepository.Create(user);
            _userRepository.AddRole(userRole);
        }
    }
}