using System.ComponentModel.DataAnnotations;

namespace Klinika.Models
{
    public class AddLjekarVM
    {
        [Display(Name = "Ime")]
        public string? Ime { get; set; }
        [Display(Name = "Prezime")]
        public string? Prezime { get; set; }
        [Display(Name = "Titula")]
        public string? Titula { get; set; }
        [Display(Name = "Šifra")]
        public string? Sifra { get; set; }
    }
}
