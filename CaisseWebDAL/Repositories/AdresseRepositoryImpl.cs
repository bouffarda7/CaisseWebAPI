/*using CaisseWebDAL.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CaisseWebDAL.Repositories
{
    public class AdresseRepositoryImpl : MySqlRepository<Adresse>
    {
        public override void Create(Adresse adresse)
        {

            try
            {
                adresse.Id = RetreiveIdByCompleteAdresse(adresse);

                if (adresse.Id != -1)
                    return;

                EstablishConnection();

                MySqlCommand cmd = new MySqlCommand
                {
                    CommandText = "INSERT INTO adresse VALUES(NULL, @noadresse,@rue,@ville, @codepostal, @noappart);",
                    Connection = _conn,
                    CommandType = CommandType.Text
                };

                cmd.Parameters.AddWithValue("@noadresse", adresse.NoAdresse);
                cmd.Parameters.AddWithValue("@rue", adresse.Rue);
                cmd.Parameters.AddWithValue("@ville", adresse.Ville);
                cmd.Parameters.AddWithValue("@codepostal", adresse.CodePostal);
                cmd.Parameters.AddWithValue("@noappart", adresse.NoAppartement);


                int NombreLigneInserees = cmd.ExecuteNonQuery();

                if (NombreLigneInserees != 1)
                    throw new Exception();

                adresse.Id = Convert.ToInt32(cmd.LastInsertedId);

                CloseConnection();

            }
            catch (Exception e)
            {
                throw e;
            }

        }

        private int RetreiveIdByCompleteAdresse(Adresse adresse)
        {

            int Id = -1;

            try
            {
                EstablishConnection();

                MySqlCommand cmd = new MySqlCommand
                {
                    CommandText = "SELECT IdAdresse from adresse WHERE NoAdresse LIKE @noadresse AND RUE LIKE @rue AND Ville LIKE @ville" +
                    " AND CodePostal LIKE @codepostal AND (NoAppartement IS NULL OR NoAppartement LIKE @noappart);",
                    Connection = _conn,
                    CommandType = CommandType.Text
                };


                cmd.Parameters.AddWithValue("@noadresse", adresse.NoAdresse);
                cmd.Parameters.AddWithValue("@rue", adresse.Rue);
                cmd.Parameters.AddWithValue("@ville", adresse.Ville);
                cmd.Parameters.AddWithValue("@codepostal", adresse.CodePostal);
                cmd.Parameters.AddWithValue("@noappart", adresse.NoAppartement);


                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Id = reader.GetInt32("IdAdresse");
                }

                reader.Close();

                CloseConnection();

            }
            catch (MysqlException e)
            {
                throw e;
            }

            return Id;
        }

        public override void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public override List<Adresse> RetreiveAll()
        {
            throw new NotImplementedException();
        }

        public override Adresse RetreiveById(int id)
        {
            throw new NotImplementedException();
        }

        public override void Update(Adresse objet)
        {
            throw new NotImplementedException();
        }
    }
}
*/