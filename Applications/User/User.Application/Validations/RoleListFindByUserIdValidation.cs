using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using User.Application.Queries;

namespace User.Application.Validations
{
    public class RoleListFindByUserIdValidation: AbstractValidator<RoleListFindByUserIdQuery>
    {
        public RoleListFindByUserIdValidation()
        {
            RuleFor(x => x.UserId).NotEqual(default(Guid)).WithMessage("'UserId' alanı için geçerli bir değer girin.");
        }
    }
}
