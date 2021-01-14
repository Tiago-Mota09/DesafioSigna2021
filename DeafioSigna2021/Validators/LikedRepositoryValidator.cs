using DeafioSigna2021.Domain.Models.Request;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeafioSigna2021.Validators
{
    public class LikedRepositoryValidator : AbstractValidator<LikedRepositoryRequest>
    {
        public LikedRepositoryValidator()
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.IdRepository)
                .NotEmpty().WithMessage("Informe o nome")
                .MinimumLength(10).WithMessage("O nome deve ter no mínimo 3 caracteres")
                .MaximumLength(150).WithMessage("O nome deve ter no máximo 150 caracteres")
                .DependentRules(() =>
                {
                    RuleFor(x => x.Status);
                       
                });
        }
    }
}
