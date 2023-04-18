using CarWorkshop.Application.DTO;
using CarWorkshop.Domain.Interfaces;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Application.Mediator.Commands.CreateCarWorkshop
{
    public class CreateCarWorkshopCommandValidator : AbstractValidator<CreateCarWorkshopCommand>
    {
        public CreateCarWorkshopCommandValidator(ICarWorkshopRepository repository)
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("To pole jest wymagane")
                .MinimumLength(2)
                .MaximumLength(20)
                .Custom((value, context) =>
                {
                    var existingCarWorkshop = repository.GetByName(value).Result;
                    if (existingCarWorkshop != null)
                    {
                        context.AddFailure($"Podana nazwa: {value} już istnieje w bazie danych");
                    }
                });

            RuleFor(c => c.Description)
                .NotEmpty().WithMessage("To pole jest wymagane");

            RuleFor(c => c.PhoneNumber)
                .MinimumLength(8).WithMessage("Minimum 8 znaków")
                .MaximumLength(12).WithMessage("Maksimum 12 znaków");
        }
    }
}
