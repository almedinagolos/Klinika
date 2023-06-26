using Klinika.Database;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Klinika.Models
{
    public class IndexNalazVM
    {

        public List<Nalaz> Nalazi { get; set; }
        public int? PrijemId { get; set; }
    }
}
