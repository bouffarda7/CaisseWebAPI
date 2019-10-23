using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaisseWebAPI.DAL
{
    public class TypeRabais : DAO
    {
        public string NomType { get; set; }

        public List<Rabais> Rabais { get; set; }

    }
}
