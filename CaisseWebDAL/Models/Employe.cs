using System;
using System.Collections.Generic;
using System.Text;

namespace CaisseWebDAL.Models
{
    public class Employe : DAO
    {
        public Compte Compte { get; set; }
        public string NomUtilisateur { get; set; }
        public string MPEmploye { get; set; }
        public bool isAdmin { get; set; }
        public DateTime DateEmbauche { get; set; }
        public DateTime DateFinEmploi { get; set; }
    }
}
