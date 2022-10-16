using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class MovieValidator : AbstractValidator<Movie>
    {
        public MovieValidator()
        {
            RuleFor(x => x.Name)
                        .NotEmpty()
                        .NotNull().WithMessage("Film alanı boş geçilemez")
                        .MinimumLength(2).WithMessage("En az {MinLength} karakter olmalıdır")
                        .MaximumLength(30).WithMessage("En fazla {MaxLength} karakter olabilir");

            RuleFor(x => x.Year)
                    .NotEmpty()
                    .NotNull().WithMessage("Bu alan boş geçilemez");
        }
    }
}
