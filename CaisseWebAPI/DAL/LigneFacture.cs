using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaisseWebAPI.DAL
{
    public class LigneFacture
    {

        public int IdFacture { get; set; }
        public Facture Facture { get; set; }

        public int IdProduit { get; set; }

        public Produit Produit { get; set; }

        public int Quantite { get; set; }

        public decimal PrixRegulier { get; set; }

        public decimal? PrixAvecRabais { get; set; }

        public decimal PrixTotalLigne { get; set; }

    }
}
