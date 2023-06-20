using System.ComponentModel.DataAnnotations.Schema;

namespace Klinika.Database
{
    public class Nalaz
    {
        public int NalazId { get; set; }
        public string Opis { get; set; }
        public DateTime DatumKreiranja { get; set; }
        [ForeignKey(nameof(Prijem))]
        public int PrijemId { get; set; }
        public Prijem Prijem { get; set; }
    }
}
