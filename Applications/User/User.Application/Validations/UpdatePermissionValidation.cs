using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using User.Application.Commands;

namespace User.Application.Validations
{
    public class UpdatePermissionValidation: AbstractValidator<UpdatePermissionCommand>
    {
        public UpdatePermissionValidation()
        {
            RuleFor(x => x.Id).NotEqual(default(Guid)).WithMessage("'Id' alanı için geçerli bir değer girin.");
            RuleFor(x => x.Name).NotNull().NotEmpty().WithMessage("'Name' alanı için geçerli bir değer girin.");
            RuleFor(x => x.Code).NotNull().NotEmpty().WithMessage("'Code' alanı için geçerli bir değer girin.");
        }
    }
}
