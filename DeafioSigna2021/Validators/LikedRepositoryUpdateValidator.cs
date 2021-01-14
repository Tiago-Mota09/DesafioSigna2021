using DeafioSigna2021.Domain.Models.Request;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeafioSigna2021.Validators
{
    public class LikedRepositoryUpdateValidator : AbstractValidator<LikedRepositoryUpdateRequest>
    {
        public LikedRepositoryUpdateValidator()
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.IdLikedRepository)
               .NotNull().WithMessage("Este campo não pode ser nulo, informe o professor")
               .GreaterThan(0).WithMessage("Este campo deve ser maior que 0, informe o professor");
        }
    }
}
