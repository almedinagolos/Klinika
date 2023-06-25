using System.ComponentModel.DataAnnotations;

namespace Klinika.Helper
{
    public enum SpolEnum
    {
        [Display(Name = "Muško")] Musko = 1,
        [Display(Name = "Žensko")] Zensko = 2,
        [Display(Name = "Nepoznato")] Nepoznato = 3
    }
}
