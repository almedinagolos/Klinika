using System.ComponentModel.DataAnnotations;

namespace Klinika.Helper
{
    public enum TitulaEnum
    {
        [Display(Name = "Specijalista")] Specijalista = 1,
        [Display(Name = "Specijalizant")] Specijalizant = 2,
        [Display(Name = "Medicinska sestra")] MedicinskaSestra = 3
    }
}
