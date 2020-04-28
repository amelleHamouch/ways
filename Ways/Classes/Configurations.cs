using MySql.Data.MySqlClient;

namespace Ways.Classes
{
    class Configurations
    {
        public static MySqlConnection connection = new MySqlConnection("server = 127.0.0.1; database=ways;uid=root;pwd=root");

    }
} 

