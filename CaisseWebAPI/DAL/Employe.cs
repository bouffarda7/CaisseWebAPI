using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaisseWebAPI.DAL
{
    public class Employe : DAO
    {
        public string NomUtilisateur { get; set; }
        public string MotPasse { get; set; }
        public bool EstAdmin { get; set; }
        public DateTime DateEmbauche { get; set; }
        public DateTime DateFinEmploi { get; set; }

        public Compte Compte { get; set; }
        public int IdCompte { get; set; }
    }
}

