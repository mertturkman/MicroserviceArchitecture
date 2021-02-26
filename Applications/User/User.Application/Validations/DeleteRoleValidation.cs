using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using User.Application.Commands;

namespace User.Application.Validations
{
    public class DeleteRoleValidation: AbstractValidator<DeleteRoleCommand>
    {
        public DeleteRoleValidation()
        {
            RuleFor(x => x.RoleId).NotEqual(default(Guid)).WithMessage("'RoleId' alanı için geçerli bir değer girin.");
        }
    }
}
