using System;
using System.Collections.Generic;
using System.Text;

namespace CaisseWebDAL.Models
{
    public class Produit : DAO
    {
        public string CodeProduit { get; set; }

        public string NomProduit { get; set; }

        public string DescriptionProduit { get; set; }

        public decimal PrixProduit { get; set; }

        public int QuantiteProduit { get; set; }

        public bool StatusProduit { get; set; }

        public Rabais Rabais { get; set; }

        public List<CategorieProduit> CategoriesProduit { get; set; }
    }
}
