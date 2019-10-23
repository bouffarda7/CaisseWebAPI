using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaisseWebAPI.DAL
{
    public class CategorieProduit : DAO
    {
        public string NomCategorie { get; set; }

        public string DescriptionCategorie { get; set; }

        public bool StatusCategorie { get; set; }

        public List<RelProduitCategorie> RelProduitCategories { get; set; }

    }
}
