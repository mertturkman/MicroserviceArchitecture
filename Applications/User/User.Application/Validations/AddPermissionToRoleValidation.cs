using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using User.Application.Commands;

namespace User.Application.Validations
{
    public class AddPermissionToRoleValidation: AbstractValidator<AddPermissionToRoleCommand>
    {
        public AddPermissionToRoleValidation()
        {
            RuleFor(x => x.PermissionId).NotEqual(default(Guid)).WithMessage("Lütfen geçerili bir 'PermissionId' girin.");
            RuleFor(x => x.RoleId).NotEqual(default(Guid)).WithMessage("Lütfen geçerili bir 'RoleId' girin.");
        }
    }
}
