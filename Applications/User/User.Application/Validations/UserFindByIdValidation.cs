using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using User.Application.Queries;

namespace User.Application.Validations
{
    public class UserFindByIdValidation: AbstractValidator<UserFindByIdQuery>
    {
        public UserFindByIdValidation()
        {
            //RuleFor(x => x.Id).Empty().WithMessage("'Id' alanı için geçerli bir değer girin.");
        }
    }
}
