using Agricathon2022;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EFCoreApp2021
{
    public class Parcelle
    {
        [Required]
        public int NoParcelle { get; set; }
        [Key]
        [Required]
        public string EGRID { get; set; }
        [Required]
        public string Cepage { get; set; }
        [Required]
        public string Address { get; set; }

        [Required]
        public int Surface { get; set; }

       
        public int ExploitantID { get; set; }
        public virtual Exploitant Exploitant { get; set; }

        public int ProprietaireID { get; set; }
        public virtual Proprietaire Propietaire { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }


        [Required]
        public Boolean Vente { get; set;}
        [Required]
        public Boolean Location { get; set; }

        public double Prix { get; set; }

        public string InfosSupp { get; set; }

        public int Age { get; set; }
    }
}
