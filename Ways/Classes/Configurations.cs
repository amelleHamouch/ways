using MySql.Data.MySqlClient;
using System;
using System.Configuration;

namespace Ways.Classes
{
    class Configurations
    {
        /// <summary>
        /// Paramètre de connexion à la base de données
        /// </summary>
        public static MySqlConnection connection = new MySqlConnection("server=127.0.0.1;user=root;database=ways;port=3306;password=root;");

        public static implicit operator Configuration(Configurations v)
        {
            throw new NotImplementedException();
        }
    }
} 

