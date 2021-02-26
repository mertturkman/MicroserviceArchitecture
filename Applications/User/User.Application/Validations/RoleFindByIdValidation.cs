using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using User.Application.Queries;

namespace User.Application.Validations
{
    public class RoleFindByIdValidation: AbstractValidator<RoleFindByIdQuery>
    {
        public RoleFindByIdValidation()
        {
            RuleFor(x => x.Id).NotEqual(default(Guid)).WithMessage("'Id' alanı için geçerli bir değer girin.");
        }
    }
}
