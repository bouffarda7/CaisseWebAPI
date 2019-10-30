using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaisseWebAPI.DAL
{
    public class Facture : DAO
    {
        public Employe Employe { get; set; }
        public int IdEmploye { get; set; }

        public Compte Compte { get; set; }

        public int IdCompte { get; set; }

        public DateTime DateFacture { get; set; }

        public decimal SousTotal { get; set; }


        public decimal TotalTaxe { get; set; }


        public decimal TotalAvecTaxe { get; set; }


        public int? IdRabais { get; set; }

        public Rabais RabaisFacture { get; set; }

        public string CommentaireFacture { get; set; }

    }
}
