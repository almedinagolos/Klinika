using Klinika.Database;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Klinika.Models
{
    public class AddNalazVM
    {
      
        [Display(Name = "Opis")]
        public string? Opis { get; set; }
        [Display(Name = "DatumKreiranja")]
        public DateTime? DatumKreiranja { get; set; }
        public int? PrijemId { get; set; }
    }
}
