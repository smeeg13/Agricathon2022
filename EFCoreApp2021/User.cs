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
        [Required]
        public string Firstname { get; set; }
        [Required]
        public string Lastname { get; set; }
        [Required]
        public string NoExploitant { get; set; }
        public DateTime DateNaissance { get; set; }
        [Required]
        public string Address { get; set; }

        public virtual ICollection<Parcelle> Parcelles { get; set; }

        [Required]
        public Boolean Exploitant { get; set; }
        [Required]
        public Boolean Proprietaire { get; set; }
        [Required]
        public string Email { get; set; }
         [Required]
        public string Password { get; set; }
    }
}
