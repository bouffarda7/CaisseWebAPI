using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaisseWebAPI.DAL
{
    public class TypeTelephone : DAO
    {
        public string NomType { get; set; }

        public List<Telephone> Telephones { get; set; }
    }
}
