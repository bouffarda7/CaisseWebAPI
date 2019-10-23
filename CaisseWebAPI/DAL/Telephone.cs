using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaisseWebAPI.DAL
{
    public class Telephone : DAO
    {
        public string NumeroTelephone { get; set; }

        public int IdTypeTelephone { get; set; }

        public TypeTelephone TypeTelephone { get; set; }

        public List<CompteTelephone> CompteTelephones { get; set; }
    }
}
