using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;


namespace EFCoreApp2021
{
    public class Transaction
    {
        [Key]
        public int TransactionID { get; set; }
        public int AcquereurId { get; set; }

        //[ForeignKey("user")]
        //public virtual User Acquereur { get; set; }

        //public int VendeurId { get; set; }

        //[ForeignKey("vendeurid")]
        //public virtual User Vendeur { get; set; }

        public int EGRID { get; set; }
        public virtual Parcelle Parcelle { get; set; }

        public Boolean Vente { get; set; }
        public double Prix { get; set; }
        public string Commentaire { get; set; }
        public DateTime Date { get; set; }
    }
}
