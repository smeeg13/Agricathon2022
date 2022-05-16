using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;


namespace EFCoreApp2021
{
    public class User
    {
        [Key]
        public int UserID { get; set; }

        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string NoExploitant { get; set; }
        public DateTime DateNaissance { get; set; }
        public string Address { get; set; }
        public virtual ICollection<Parcelle> Parcelles { get; set; }

        public Boolean Exploitant { get; set; }
        public Boolean Proprietaire { get; set; }
        public string Email { get; set; }
    }
}
