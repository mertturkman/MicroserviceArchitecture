using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using User.Application.Commands;

namespace User.Application.Validations
{
    public class DeleteUserValidation: AbstractValidator<DeleteUserCommand>
    {
        public DeleteUserValidation()
        {
            RuleFor(x => x.UserId).NotEqual(default(Guid)).WithMessage("'UserId' alanı için geçerli bir değer girin.");
        }
    }
}
