using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EFCoreApp2021
{
    public class Parcelle
    {
        [Key]
        [Required]
        public int NoParcelle { get; set; }
        [Required]
        public string EGRID { get; set; }
        [Required]
        public string Cepage { get; set; }
        [Required]
        public string Address { get; set; }

        [Required]
        public int Surface { get; set; }

        [Required]
        public int ExploitantID { get; set; }
        public virtual User ExploitantSet { get; set; }

        [Required]
        public int ProrietaireID { get; set; }
        public virtual User PropietaireSet { get; set; }

        [Required]
        public Boolean Vente { get; set;}
        [Required]
        public Boolean Location { get; set; }

        public double Prix { get; set; }

        public string InfosSupp { get; set; }

        public int Age { get; set; }
    }
}
