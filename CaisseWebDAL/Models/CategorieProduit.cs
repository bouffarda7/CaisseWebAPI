namespace CaisseWebDAL.Models
{
    public class CategorieProduit : DAO
    {
        public string NomCategorie { get; set; }

        public string DescriptionCategorie { get; set; }

        public bool StatusCategorie { get; set; }
    }
}