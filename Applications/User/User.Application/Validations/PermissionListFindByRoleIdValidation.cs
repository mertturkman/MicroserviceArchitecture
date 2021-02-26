using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using User.Application.Queries;

namespace User.Application.Validations
{
    public class PermissionListFindByRoleIdValidation: AbstractValidator<PermissionListFindByRoleIdQuery>
    {
        public PermissionListFindByRoleIdValidation()
        {
            RuleFor(x => x.RoleId).NotEqual(default(Guid)).WithMessage("'RoleId' alanı için geçerli bir değer girin.");
        }
    }
}
