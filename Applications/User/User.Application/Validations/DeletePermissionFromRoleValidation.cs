using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using User.Application.Commands;

namespace User.Application.Validations
{
    public class DeletePermissionFromRoleValidation: AbstractValidator<DeletePermissionFromRoleCommand>
    {
        public DeletePermissionFromRoleValidation()
        {
            RuleFor(x => x.RolePermissionId).NotEqual(default(Guid)).WithMessage("'RolePermissionId' alanı için geçerli bir değer girin.");
        }
    }
}
