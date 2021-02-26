using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using User.Application.Commands;

namespace User.Application.Validations
{
    public class CreateRoleValidation: AbstractValidator<CreateRoleCommand>
    {
        public CreateRoleValidation()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty().WithMessage("'Name' alanı için geçerli bir değer girin.");
        }
    }
}
