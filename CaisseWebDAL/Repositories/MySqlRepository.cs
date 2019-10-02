using CaisseWebDAL.Helpers;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace CaisseWebDAL.Repositories
{
    public abstract class MySqlRepository<T> where T : Models.DAO
    {
        protected MySqlConnection _conn = null;

        public abstract List<T> RetreiveAll();

        public abstract T RetreiveById(int id);

        public abstract void Create(T objet);

        public abstract void Update(T objet);

        public abstract void Delete(int id);

        protected void EstablishConnection()
        {
            try
            {
                _conn = new MySqlConnection
                {
                    ConnectionString = DBConfigHelper.GetConnectionString()
                };

                _conn.Open();
            }
            catch (MySqlException e)
            {
                throw e;
            }
        }

        protected void CloseConnection()
        {
            if (_conn.State == System.Data.ConnectionState.Open)
                _conn.Close();
        }
    }
}

