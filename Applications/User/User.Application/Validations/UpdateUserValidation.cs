using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using User.Application.Commands;

namespace User.Application.Validations
{
    public class UpdateUserValidation: AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserValidation()
        {
            RuleFor(x => x.Id).NotEqual(default(Guid)).WithMessage("'Id' alanı için geçerli bir değer girin.");
            RuleFor(x => x.Name).NotNull().NotEmpty().WithMessage("'Name' alanı için geçerli bir değer girin.");
            RuleFor(x => x.Surname).NotNull().NotEmpty().WithMessage("'Surname' alanı için geçerli bir değer girin.");
            RuleFor(x => x.Mail).NotNull().NotEmpty().WithMessage("'Mail' alanı için geçerli bir değer girin.");
        }
    }
}
