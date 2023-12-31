﻿using System.ComponentModel.DataAnnotations;

namespace Klinika.Models
{
    public class UpdatePacijentVM
    {
        public int PacijentId { get; set; }
        [Display(Name = "Ime i prezime")]

        public string? ImePrezime { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Datum rođenja")]

        public DateTime? DatumRodjenja { get; set; }
        [Display(Name = "Spol")]
        public string? Spol { get; set; }
        [Display(Name = "Adresa")]

        public string? Adresa { get; set; }
        [Display(Name = "Broj telefona")]

        public string? BrojTelefona { get; set; }
    }
}