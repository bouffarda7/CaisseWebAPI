using CaisseWebDAL.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CaisseWebDAL.Helpers
{
    public static class DBConfigHelper
    {
        public static string GetConnectionString()
        {
            string json = File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DBConfig.json"));
            var result = JsonConvert.DeserializeObject<DBConfig>(json);

            return BuildString(result);

        }

        private static string BuildString(DBConfig cnf)
        {

            string retour = string.Empty;

            retour += "server=" + cnf.Host + ";uid=" + cnf.User + ";pwd=" + cnf.Password + ";database=" +
                        cnf.Database;

            return retour;

        }
    }
}
