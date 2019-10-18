using System;
using System.Collections.Generic;
using System.Text;

namespace CaisseWebDAL.Models
{
    public class Facture : DAO
    {
        public Employe EmployeFacture { get; set; }

        public Compte CompteFacture { get; set; }

        public DateTime DateFacture { get; set; }
    }
}
