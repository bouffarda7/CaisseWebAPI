using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CaisseWebDAL.Models
{
    public class Compte : DAO
    {
        public string NomPers { get; set; }

        public string PrenomPers { get; set; }

        public string EmailPers { get; set; }

        public Adresse Adresse { get; set; }

        public List<Telephone> Telephones { get; set; }

        public string NomUtil { get; set; }

        public string MPUtil { get; set; }

        public DateTime DateInscription { get; set; }

        public DateTime DateNaissance { get; set; }

        public bool StatusCompte { get; set; }

    }

}
