using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaisseWebAPI.DAL
{
    public class RelProduitCategorie
    {
        public int IdProduit { get; set; }
        public Produit Produit { get; set; }

        public int IdCategorie { get; set; }
        public CategorieProduit Categorie { get; set; }
    }
}
