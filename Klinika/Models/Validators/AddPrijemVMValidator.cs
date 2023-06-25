using FluentValidation;

namespace Klinika.Models.Validators
{
    public class AddPrijemVMValidator : AbstractValidator<AddPrijemVM>
    {
        public AddPrijemVMValidator()
        {
            RuleFor(x => x.DatumPrijema).GreaterThanOrEqualTo(DateTime.Now.Date).WithMessage("Datum prijema mora biti veći ili jednak današnjem");
            RuleFor(x => x.PacijentId).NotEqual(0).WithMessage("Obavezno je odabrati pacijenta!");
            RuleFor(x => x.LjekarId).NotEqual(0).WithMessage("Obavezno je unijeti ljekara!");
            RuleFor(x => x.HitniPrijem).NotEmpty().WithMessage("Obavezno je odabrati hitnost prijema!");
        }
    }
}
