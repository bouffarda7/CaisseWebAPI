using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaisseWebAPI.DAL
{
    public class Adresse : DAO
    {
        public string NumeroCivique { get; set; }

        public string Rue { get; set; }

        public string Ville { get; set; }

        public string CodePostal { get; set; }

        public string NumeroAppartement { get; set; }

        public List<Compte> Comptes { get; set; }
    }
}
