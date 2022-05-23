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

        public string NoExploitant { get; set; }

        public Boolean EstExploitant { get; set; }
        public Boolean EstPropriétaire { get; set; }
        
      
        public DateTime DateNaissance { get; set; }
        [Required]
        public string Address { get; set; }


        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
