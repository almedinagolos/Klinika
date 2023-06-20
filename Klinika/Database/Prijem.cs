using System.ComponentModel.DataAnnotations.Schema;

namespace Klinika.Database
{
    public class Prijem
    {
        public int PrijemId { get; set; }
        public DateTime DatumPrijema { get; set; }

        [ForeignKey(nameof(Pacijent))]
        public int PacijentId { get; set; }
        public Pacijent Pacijent { get; set; }

        [ForeignKey(nameof(Ljekar))]
        public int LjekarId { get; set; }
        public Ljekar Ljekar { get; set; }
        public byte HitniPrijem { get; set; }
    }
}
