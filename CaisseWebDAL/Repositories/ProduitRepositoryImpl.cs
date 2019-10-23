/*using CaisseWebDAL.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CaisseWebDAL.Repositories
{
    public class ProduitRepositoryImpl : MySqlRepository<Produit>
    {
        public override void Create(Produit objet)
        {
            throw new NotImplementedException();
        }

        public override void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public override List<Produit> RetreiveAll()
        {
            List<Produit> Produits = new List<Produit>();
            Produit Produit = new Produit();
            TypeRabais TypeRabais = new TypeRabais();
            Rabais Rabais = new Rabais() {TypeRabais = TypeRabais };
            List<CategorieProduit> CategoriesProduit = new List<CategorieProduit>();

           

            try
            {
                EstablishConnection();

                MySqlCommand cmd = new MySqlCommand
                {
                    CommandText = "SELECT p.IdProduit, p.CodeProduit, p.NomProduit, p.DescriptionProduit, " +
                    "p.PrixProduit, p.QuantiteProduit, p.StatusProduit, p.IdRabais, cp.IdCategorie, " +
                    "cp.NomCategorie, cp.DescriptionCategorie, cp.StatusCategorie, r.DateDebut, r.DateFin, " +
                    "r.Param1, r.Param2, tr.IdType, tr.TypeRabais from produit p join relproduitcategorie rpc on p.IdProduit = rpc.IdProduit " +
                    "join categorieproduit cp on rpc.IdCategorie = cp.IdCategorie left outer join rabais r on p.IdRabais = r.IdRabais " +
                    "left outer join typerabais tr on r.IdType = tr.IdType ;",
                    Connection = _conn,
                    CommandType = CommandType.Text
                };

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    if (!Produits.Exists(c => c.Id == reader.GetInt32("IdProduit")))
                    {
                        if(reader["IdRabais"] != DBNull.Value)
                        {
                            TypeRabais = new TypeRabais
                            {
                                Id= reader.GetInt32("IdType"),
                                Type = reader.GetString("TypeRabais")
                            };

                            Rabais = new Rabais
                            {
                                Id = reader.GetInt32("IdRabais"),
                                TypeRabais = TypeRabais,
                                DateDebut = reader.GetDateTime("DateDebut"),
                                DateFin = reader.GetDateTime("DateFin"),
                                Param1 = reader.GetFloat("Param1"),
                                Param2 = reader["Param2"] == DBNull.Value ? 0.0f : reader.GetFloat("Param2")
                                
                            };
                        }

                        Produits.Add(new Produit
                        {
                            Id = reader.GetInt32("IdProduit"),
                            CodeProduit = reader.GetString("CodeProduit"),
                            NomProduit = reader.GetString("NomProduit"),
                            DescriptionProduit = reader.GetString("DescriptionProduit"),
                            PrixProduit = reader.GetDecimal("PrixProduit"),
                            QuantiteProduit = reader.GetInt32("QuantiteProduit"),
                            StatusProduit = reader.GetBoolean("StatusProduit"),
                            Rabais = Rabais,
                            CategoriesProduit = CategoriesProduit
                            

                        });

                        Produits.Find(p => p.Id == reader.GetInt32("IdProduit"))
                            .CategoriesProduit.Add( new CategorieProduit                     
                            {
                                Id = reader.GetInt32("IdCategorie"),
                                NomCategorie = reader.GetString("NomCategorie"),
                                DescriptionCategorie = reader.GetString("DescriptionCategorie"),
                                StatusCategorie = reader.GetBoolean("StatusCategorie")
                        
                            });

                    }
                    else
                    {
                        Produits.Find(p => p.Id == reader.GetInt32("IdProduit"))
                            .CategoriesProduit.Add(new CategorieProduit
                            {
                                Id = reader.GetInt32("IdCategory"),
                                NomCategorie = reader.GetString("NomCategory"),
                                DescriptionCategorie = reader.GetString("DescriptionCategory"),
                                StatusCategorie = reader.GetBoolean("StatusCategory")

                            });
                    }
                }

                reader.Close();

                CloseConnection();

            }
            catch (MysqlException e)
            {
                throw e;
            }

            return Produits;
        }

        public override Produit RetreiveById(int id)
        {
            List<Produit> Produits = new List<Produit>();
            Produit Produit = new Produit();
            TypeRabais TypeRabais = new TypeRabais();
            Rabais Rabais = new Rabais() { TypeRabais = TypeRabais };
            List<CategorieProduit> CategoriesProduit = new List<CategorieProduit>();



            try
            {
                EstablishConnection();

                MySqlCommand cmd = new MySqlCommand
                {
                    CommandText = "SELECT p.IdProduit, p.CodeProduit, p.NomProduit, p.DescriptionProduit, " +
                    "p.PrixProduit, p.QuantiteProduit, p.StatusProduit, p.IdRabais, cp.IdCategorie, " +
                    "cp.NomCategorie, cp.DescriptionCategorie, cp.StatusCategorie, r.DateDebut, r.DateFin, " +
                    "r.Param1, r.Param2, tr.IdType, tr.TypeRabais from produit p join relproduitcategorie rpc on p.IdProduit = rpc.IdProduit " +
                    "join categorieproduit cp on rpc.IdCategorie = cp.IdCategorie left outer join rabais r on p.IdRabais = r.IdRabais " +
                    "left outer join typerabais tr on r.IdType = tr.IdType WHERE p.IdProduit = @id;",
                    Connection = _conn,
                    CommandType = CommandType.Text
                };
                cmd.Parameters.AddWithValue("@id", id);

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    if (!Produits.Exists(c => c.Id == reader.GetInt32("IdProduit")))
                    {
                        if (reader["IdRabais"] != DBNull.Value)
                        {
                            TypeRabais = new TypeRabais
                            {
                                Id = reader.GetInt32("IdType"),
                                Type = reader.GetString("TypeRabais")
                            };

                            Rabais = new Rabais
                            {
                                Id = reader.GetInt32("IdRabais"),
                                TypeRabais = TypeRabais,
                                DateDebut = reader.GetDateTime("DateDebut"),
                                DateFin = reader.GetDateTime("DateFin"),
                                Param1 = reader.GetFloat("Param1"),
                                Param2 = reader["Param2"] == DBNull.Value ? 0.0f : reader.GetFloat("Param2")

                            };
                        }

                        Produits.Add(new Produit
                        {
                            Id = reader.GetInt32("IdProduit"),
                            CodeProduit = reader.GetString("CodeProduit"),
                            NomProduit = reader.GetString("NomProduit"),
                            DescriptionProduit = reader.GetString("DescriptionProduit"),
                            PrixProduit = reader.GetDecimal("PrixProduit"),
                            QuantiteProduit = reader.GetInt32("QuantiteProduit"),
                            StatusProduit = reader.GetBoolean("StatusProduit"),
                            Rabais = Rabais,
                            CategoriesProduit = CategoriesProduit


                        });

                        Produits.Find(p => p.Id == reader.GetInt32("IdProduit"))
                            .CategoriesProduit.Add(new CategorieProduit
                            {
                                Id = reader.GetInt32("IdCategorie"),
                                NomCategorie = reader.GetString("NomCategorie"),
                                DescriptionCategorie = reader.GetString("DescriptionCategorie"),
                                StatusCategorie = reader.GetBoolean("StatusCategorie")

                            });

                    }
                    else
                    {
                        Produits.Find(p => p.Id == reader.GetInt32("IdProduit"))
                            .CategoriesProduit.Add(new CategorieProduit
                            {
                                Id = reader.GetInt32("IdCategory"),
                                NomCategorie = reader.GetString("NomCategory"),
                                DescriptionCategorie = reader.GetString("DescriptionCategory"),
                                StatusCategorie = reader.GetBoolean("StatusCategory")

                            });
                    }
                }

                reader.Close();

                CloseConnection();

            }
            catch (MysqlException e)
            {
                throw e;
            }

            return Produits.First();
        }

        public override void Update(Produit objet)
        {
            throw new NotImplementedException();
        }
    }
}
*/