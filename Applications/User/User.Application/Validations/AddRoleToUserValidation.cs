using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using User.Application.Commands;

namespace User.Application.Validations
{
    public class AddRoleToUserValidation: AbstractValidator<AddRoleToUserCommand>
    {
        public AddRoleToUserValidation()
        {
            RuleFor(x => x.UserId).NotEqual(default(Guid)).WithMessage("Lütfen geçerili bir 'UserId' girin.");
            RuleFor(x => x.RoleId).NotEqual(default(Guid)).WithMessage("Lütfen geçerili bir 'RoleId' girin.");
        }
    }
}
