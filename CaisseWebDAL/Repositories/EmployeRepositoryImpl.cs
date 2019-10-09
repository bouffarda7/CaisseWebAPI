using CaisseWebDAL.Helpers;
using CaisseWebDAL.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CaisseWebDAL.Repositories
{
    public class EmployeRepositoryImpl : MySqlRepository<Employe>
    {
        public override void Create(Employe employe)
        {
            try
            {
                EstablishConnection();

                MySqlCommand cmd = new MySqlCommand
                {
                    CommandText = "INSERT INTO employe VALUES(NULL, @idcompte, @nomutilisateur, " +
                    "@mpemploye, DEFAULT, @dateembauche, NULL);",
                    Connection = _conn,
                    CommandType = CommandType.Text
                };

                cmd.Parameters.AddWithValue("@idcompte", employe.Compte.Id);
                cmd.Parameters.AddWithValue("@nomutilisateur", employe.NomUtilisateur);
                cmd.Parameters.AddWithValue("@mpemploye", PasswordHelper.HashPassword(employe.MPEmploye));
                cmd.Parameters.AddWithValue("@dateembauche", employe.DateEmbauche);



                int NombreLigneInserees = cmd.ExecuteNonQuery();

                if (NombreLigneInserees != 1)
                    throw new Exception();

                employe.Id = Convert.ToInt32(cmd.LastInsertedId);

                CloseConnection();

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public override void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public override List<Employe> RetreiveAll()
        {
            throw new NotImplementedException();
        }

        public override Employe RetreiveById(int id)
        {
            throw new NotImplementedException();
        }

        public string RetreivePasswordByUsername(string username)
        {
            string password = "";

            try
            {
                EstablishConnection();

                MySqlCommand cmd = new MySqlCommand
                {
                    CommandText = "SELECT MPEmploye FROM employe where NomUtilisateur = @nomutilisateur;",
                    Connection = _conn,
                    CommandType = CommandType.Text
                };

                cmd.Parameters.AddWithValue("@nomutilisateur", username);

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    password = reader.GetString("MPEmploye");

                }

                reader.Close();

                CloseConnection();

            }
            catch (Exception e)
            {
                throw e;
            }

            return password;
        
        }

        public override void Update(Employe objet)
        {
            throw new NotImplementedException();
        }
    }
}
