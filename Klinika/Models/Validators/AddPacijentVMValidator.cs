using FluentValidation;

namespace Klinika.Models.Validators
{
    public class AddPacijentVMValidator : AbstractValidator<AddPacijentVM>
    {
        public AddPacijentVMValidator()
        {
            RuleFor(x => x.ImePrezime).NotEmpty().WithMessage("Obavezno je unijeti ime i prezime pacijenta!");
            RuleFor(x => x.DatumRodjenja).NotEmpty().WithMessage("Obavezno je unijeti datum rođenja pacijenta!");
            RuleFor(x => x.Spol).NotEmpty().WithMessage("Obavezno je unijeti spol pacijenta!");
        }
    }
}
