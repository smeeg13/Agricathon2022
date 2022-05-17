using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;


namespace EFCoreApp2021
{
    public class Transaction
    {
        [Key]
        public int TransactionID { get; set; }

        public int AcquereurId { get; set; }
        public virtual  User Acquereur { get; set; }
        public int VendeurId { get; set; }
        public virtual User Vendeur { get; set; }

        public int EGRID { get; set; }
        public virtual Parcelle Parcelle

        public Boolean Vente { get; set; }
        public double Prix { get; set; }
        public string Commentaire { get; set; }
        public DateTime Date { get; set; }

        
    }
}
