using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaisseWebAPI.DAL
{
    public class Compte : DAO
    {
        public string Nom { get; set; }

        public string Prenom { get; set; }

        public string Email { get; set; }

        public int IdAdresse { get; set; }

        public Adresse Adresse { get; set; }

        public List<CompteTelephone> CompteTelephones { get; set; }

        public string NomUtilisateur { get; set; }

        public string MotPasse { get; set; }

        public DateTime DateInscription { get; set; }

        public DateTime DateNaissance { get; set; }

        public bool StatusCompte { get; set; }

        public List<Employe> Employe { get; set; }


    }
}
