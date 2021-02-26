using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using User.Application.Commands;

namespace User.Application.Validations
{
    public class DeletePermissionValidation: AbstractValidator<DeletePermissionCommand>
    {
        public DeletePermissionValidation()
        {
            RuleFor(x => x.PermissionId).NotEqual(default(Guid)).WithMessage("'PermissionId' alanı için geçerli bir değer girin.");
        }
    }
}
