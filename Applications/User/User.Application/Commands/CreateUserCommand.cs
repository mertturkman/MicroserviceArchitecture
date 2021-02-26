using System.Runtime.Serialization;
using User.Domain.AggregatesModel.UserAggregate;
using MediatR;
using User.Application.Abstractions.Command;

namespace User.Application.Commands {
    public class CreateUserCommand : ICommand {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Mail { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
    }
}