using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaisseWebAPI.DAL
{
    public class Rabais : DAO
    {
        public DateTime DateDebut { get; set; }

        public DateTime DateFin { get; set; }

        public float Param1 { get; set; }

        public float? Param2 { get; set; }

        public TypeRabais TypeRabais { get; set; }
        public int IdTypeRabais { get; set; }

        public List<Produit> Produits { get; set; }

        public List<Facture> Factures { get; set; }

    }
}
