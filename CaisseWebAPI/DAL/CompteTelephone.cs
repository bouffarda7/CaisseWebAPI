using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaisseWebAPI.DAL
{
    public class CompteTelephone
    {
        public int IdCompte { get; set; }
        public Compte Compte { get; set; }

        public int IdTelephone { get; set; }
        public Telephone Telephone { get; set; }
    }
}
