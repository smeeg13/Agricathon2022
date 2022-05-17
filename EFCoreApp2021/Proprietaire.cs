using EFCoreApp2021;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agricathon2022
{
    public class Proprietaire : User
    {

        public virtual ICollection<Parcelle> Parcelles { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
