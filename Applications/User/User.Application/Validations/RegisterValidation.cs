using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using User.Application.Commands;

namespace User.Application.Validations
{
    public class RegisterValidation: AbstractValidator<RegisterCommand>
    {
        public RegisterValidation()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty().WithMessage("'Name' alanı için geçerli bir değer girin.");
            RuleFor(x => x.Surname).NotNull().NotEmpty().WithMessage("'Surname' alanı için geçerli bir değer girin.");
            RuleFor(x => x.Username).NotNull().NotEmpty().WithMessage("'Username' alanı için geçerli bir değer girin.");
            RuleFor(x => x.Mail).EmailAddress().WithMessage("'Mail' alanı için geçerli bir değer girin.");
            RuleFor(x => x.Password).NotNull().NotEmpty().WithMessage("'Password' alanı için geçerli bir değer girin.");
        }
    }
}
