using FluentValidation;

namespace Klinika.Models.Validators
{
    public class AddNalazVMValidator : AbstractValidator<AddNalazVM>
    {
        public AddNalazVMValidator()
        {
            RuleFor(x => x.Opis).NotEmpty().WithMessage("Obavezno je unijeti opis nalaza!");
        }
    }
}
