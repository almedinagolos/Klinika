using System.ComponentModel.DataAnnotations;

namespace Klinika.Models
{
    public class Pacijent
    {
        public int PacijentId { get; set; }
        public string ImePrezime { get; set; }
        [DataType(DataType.Date)]
        public DateTime DatumRodjenja { get; set; }
        public string Spol { get; set; }
        public string? Adresa { get; set; }
        public string? BrojTelefona { get; set; }
    }
}
