using System;
using System.Collections.Generic;
using System.Text;

namespace CaisseWebDAL.Models
{
    public class Telephone : DAO
    {
        public string NoTelephone { get; set; }

        public TypeTelephone TypeTelephone { get; set; }
    }
}
