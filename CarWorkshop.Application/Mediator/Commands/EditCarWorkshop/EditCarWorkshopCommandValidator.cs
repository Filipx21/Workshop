using CarWorkshop.Application.Mediator.Commands.CreateCarWorkshop;
using CarWorkshop.Domain.Interfaces;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Application.Mediator.Commands.EditCarWorkshop
{
    public class EditCarWorkshopCommandValidator : AbstractValidator<EditCarWorkshopCommand>
    {
        public EditCarWorkshopCommandValidator(ICarWorkshopRepository repository)
        {
            RuleFor(c => c.Description)
                .NotEmpty().WithMessage("To pole jest wymagane");

            RuleFor(c => c.PhoneNumber)
                .MinimumLength(8).WithMessage("Minimum 8 znaków")
                .MaximumLength(12).WithMessage("Maksimum 12 znaków");

            RuleFor(c => c.City)
                .NotEmpty().WithMessage("To pole jest wymagane");
        }
    }
}
