using System;

namespace CaisseWebDAL.Models
{
    public class Rabais : DAO
    {
        public TypeRabais TypeRabais { get; set; }

        public DateTime DateDebut { get; set; }

        public DateTime DateFin { get; set; }

        public float Param1 { get; set; }

        public float Param2 { get; set; }
    }
}