using Klinika.Database;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Klinika.Models
{
    public class UpdatePrijemVM
    {
        public UpdatePrijemVM()
        {
            Pacijenti = new List<SelectListItem>();
            Ljekari = new List<SelectListItem>();
        }
        public int PrijemId { get; set; }
        public DateTime DatumPrijema { get; set; }
        public int PacijentId { get; set; }
        public List<SelectListItem> Pacijenti { get; set; }
        public int LjekarId { get; set; }
        public List<SelectListItem> Ljekari { get; set; }
        public string? HitniPrijem { get; set; }
    }
}
