using FluentValidation;
using System;
using User.Application.Queries;

namespace User.Application.Validations
{
    public class PermissionFindByIdValidation: AbstractValidator<PermissionFindByIdQuery>
    {
        public PermissionFindByIdValidation()
        {
            RuleFor(x => x.Id).NotEqual(default(Guid)).WithMessage("'Id' alanı için geçerli bir değer girin.");
        }
    }
}
