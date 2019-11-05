using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaisseWebAPI.DAL
{
    public class Paiement : DAO
    {
        public int IdFacture { get; set; }

        public Facture Facture { get; set; }

        public int IdMethode { get; set; }

        public MethodePaiement MethodePaiement { get; set; } 

        public decimal MontantPaiment { get; set; }
    }
}
