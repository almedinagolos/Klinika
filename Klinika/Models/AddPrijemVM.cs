using Klinika.Database;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Klinika.Models
{
    public class AddPrijemVM
    {
        public AddPrijemVM()
        {
            Pacijenti = new List<SelectListItem>();
            Ljekari = new List<SelectListItem>(); 
        }

        public DateTime DatumPrijema { get; set; }
        public int PacijentId { get; set; }
        public List<SelectListItem> Pacijenti { get; set; }
        public int LjekarId { get; set; }
        public List<SelectListItem> Ljekari { get; set; }
        public string? HitniPrijem { get; set; }
    }
           
}
