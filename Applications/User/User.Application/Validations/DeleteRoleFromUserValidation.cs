using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using User.Application.Commands;

namespace User.Application.Validations
{
    public class DeleteRoleFromUserValidation: AbstractValidator<DeleteRoleFromUserCommand>
    {
        public DeleteRoleFromUserValidation()
        {
            RuleFor(x => x.UserRoleId).NotEqual(default(Guid)).WithMessage("'UserRoleId' alanı için geçerli bir değer girin.");
        }
    }
}
