namespace CaisseWebDAL.Models
{
    public class Adresse : DAO
    {
        public string NoAdresse { get; set; }

        public string Rue { get; set; }

        public string Ville { get; set; }

        public string CodePostal { get; set; }

        public string NoAppartement { get; set; }

    }
}