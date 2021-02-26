using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using User.Application.Commands;

namespace User.Application.Validations
{
    public class ChangePasswordValidation: AbstractValidator<ChangePasswordCommand>
    {
        public ChangePasswordValidation()
        {
            RuleFor(x => x.UserId).NotEqual(default(Guid)).WithMessage("'PermissionId' alanı için geçerli bir değer girin.");
            RuleFor(x => x.NewPassword).NotNull().NotEmpty().WithMessage("'NewPassword' alanı için geçerli bir değer girin.");
        }
    }
}
