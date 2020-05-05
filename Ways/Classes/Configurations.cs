using MySql.Data.MySqlClient;
using System;
using System.Configuration;

namespace Ways.Classes
{
    class Configurations
    {
        public static MySqlConnection connection = new MySqlConnection("server =127.0.0.1;user=root;database=ways;port=3306;");

        public static implicit operator Configuration(Configurations v)
        {
            throw new NotImplementedException();
        }
    }
} 

