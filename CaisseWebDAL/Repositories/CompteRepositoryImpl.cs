﻿using CaisseWebDAL.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CaisseWebDAL.Repositories
{
    public class CompteRepositoryImpl : MySqlRepository<Compte>
    {
        public override void Create(Compte objet)
        {
            throw new NotImplementedException();
        }

        public override void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public override List<Compte> RetreiveAll()
        {
            List<Compte> Comptes = new List<Compte>();
            Adresse Adresse = new Adresse();
            List<Telephone> Telephones = new List<Telephone>();
            Telephone Telephone = new Telephone();
            TypeTelephone TypeTelephone = new TypeTelephone();

            try
            {
                EstablishConnection();

                MySqlCommand cmd = new MySqlCommand
                {
                    CommandText = "SELECT c.IdCompte, NomPers, PrenomPers, NomUtil, " +
                     "EmailPers, MPUtil, DateInscription, DateNaissance, StatusCompte, " +
                     "a.IdAdresse, NoAdresse, Rue, Ville, CodePostal, " +
                     "NoAppartement, t.IdTelephone, t.NoTelephone, y.IdType, y.Type " +
                     "FROM compte c JOIN adresse a on c.IdAdresse = a.IdAdresse " +
                     "Left Outer JOIN relcomptetel r on c.IdCompte= r.IdCompte " +
                     "Left Outer JOIN telephone t on r.IdTelephone = t.IdTelephone " +
                     "Left Outer JOIN typetelephone y on t.TypeTelephone = y.IdType;",
                    Connection = _conn,
                    CommandType = CommandType.Text
                };

                MySqlDataReader reader = cmd.ExecuteReader();

                while(reader.Read())
                {
                    if(!Comptes.Exists(c => c.Id == reader.GetInt32("IdCompte")))
                    {
                        Adresse = new Adresse
                        {
                            Id = reader.GetInt32("IdAdresse"),
                            NoAdresse = reader.GetString("NoAdresse"),
                            Rue = reader.GetString("Rue"),
                            Ville = reader.GetString("Ville"),
                            CodePostal = reader.GetString("CodePostal"),
                            NoAppartement = reader["NoAppartement"] == DBNull.Value ? "" : reader.GetString("NoAppartement")
                        };

                        Comptes.Add(new Compte
                        {
                            Id = reader.GetInt32("IdCompte"),
                            NomPers = reader.GetString("NomPers"),
                            PrenomPers = reader.GetString("PrenomPers"),
                            NomUtil = reader.GetString("NomUtil"),
                            EmailPers = reader.GetString("EmailPers"),
                            MPUtil = reader.GetString("MPUtil"),
                            Adresse = Adresse,
                            Telephones = Telephones,
                            DateInscription = reader.GetDateTime("DateInscription"),
                            DateNaissance = reader.GetDateTime("DateNaissance"),
                            StatusCompte = reader.GetBoolean("StatusCompte")
                        });

                        if (reader["IdType"] != DBNull.Value)
                        {
                            TypeTelephone = new TypeTelephone
                            {
                                Id = reader.GetInt32("IdType"),
                                Type = reader.GetString("Type")
                            };

                            Telephone = new Telephone
                            {
                                Id = reader.GetInt32("IdTelephone"),
                                NoTelephone = reader.GetString("NoTelephone"),
                                TypeTelephone = TypeTelephone
                            };

                            Comptes.Find(c => c.Id == reader.GetInt32("IdCompte")).Telephones.Add(Telephone);
                        }
                    }
                    else
                    {
                        TypeTelephone = new TypeTelephone
                        {
                            Id = reader.GetInt32("IdType"),
                            Type = reader.GetString("Type")
                        };

                        Telephone = new Telephone
                        {
                            Id = reader.GetInt32("IdTelephone"),
                            NoTelephone = reader.GetString("NoTelephone"),
                            TypeTelephone = TypeTelephone
                        };

                        Comptes.Find(c => c.Id == reader.GetInt32("IdCompte")).Telephones.Add(Telephone);
                    }
                }

                reader.Close();

                CloseConnection();

            }
            catch (MysqlException e)
            {
                throw e;
            }

            return Comptes;
        }

        public override Compte RetreiveById(int id)
        {
            throw new NotImplementedException();
        }

        public override void Update(Compte objet)
        {
            throw new NotImplementedException();
        }
    }
}