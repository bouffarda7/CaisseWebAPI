using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaisseWebAPI.DAL
{
    public class MethodePaiement : DAO
    {
        public string Methode { get; set; }

        public List<Paiement> Paiements { get; }
    }
}
