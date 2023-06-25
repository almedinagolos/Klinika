using FluentValidation;

namespace Klinika.Models.Validators
{
    public class EditLjekarVMValidator : AbstractValidator<UpdateLjekarVM>
    {
        public EditLjekarVMValidator()
        {
            RuleFor(x => x.Ime).NotEmpty().WithMessage("Obavezno je unijeti ime ljekara");
            RuleFor(x => x.Prezime).NotEmpty().WithMessage("Obavezno je unijeti prezime ljekara");
            RuleFor(x => x.Titula).NotEmpty().WithMessage("Obavezno je unijeti titulu ljekara");
            RuleFor(x => x.Sifra).NotEmpty().WithMessage("Obavezno je unijeti šifru ljekara");
        }
    }
}
