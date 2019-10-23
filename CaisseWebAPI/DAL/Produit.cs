using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaisseWebAPI.DAL
{
    public class Produit : DAO
    {
        public string CodeProduit { get; set; }

        public string NomProduit { get; set; }

        public string DescriptionProduit { get; set; }

        public decimal PrixProduit { get; set; }

        public int QuantiteProduit { get; set; }

        public bool StatusProduit { get; set; }

        public List<RelProduitCategorie> RelProduitCategories { get; set; }

        public int? IdRabais { get; set; }

        public Rabais Rabais { get; set; }
    }
}
