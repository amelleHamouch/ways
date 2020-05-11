using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows.Navigation;
using Ways.Vues;

namespace Ways.Classes
{
    class User
    {
        private int id;
        private string login;
        private string pass;
        private int isAdmin;
        private int score;

        public int IsAdmin { get => isAdmin; set => isAdmin = value; }
        public string Login { get => login; set => login = value; }
        public int Id { get => id; set => id = value; }
        public string Pass { get => pass; set => pass = value; }
        public int Score { get => score; set => score = value; }



        public User(string login, string pass)
        {
            this.login = login;
            this.pass = pass;
        }
        public User()
        {
            
        }
        public bool AdminConnect(User admin) {



            string login = admin.Login;
            string pass = admin.Pass;
            MySqlConnection sqlCon = Configurations.connection;

            try
            {
                if (sqlCon.State == ConnectionState.Closed)
                    sqlCon.Open();
                String query = "SELECT COUNT(1) FROM user WHERE login=@Username AND password=@Password";
                MySqlCommand sqlCmd = new MySqlCommand(query, sqlCon);
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.Parameters.AddWithValue("@Username", login);
                sqlCmd.Parameters.AddWithValue("@Password", pass);
                int count = Convert.ToInt32(sqlCmd.ExecuteScalar());
                if (count == 1)
                {
                    Console.WriteLine("Réussi");
                    sqlCon.Close();
                    return true;
                }
                else
                {
                    Console.WriteLine("LOUPé");
                    sqlCon.Close();
                    return false;

                }
            }
            catch (Exception ex)
            {

                Console.WriteLine( ex.Message);
                return false;
            }
          
        }
     
        public int CreateUser(String username)
        {

            MySqlConnection sqlCon = Configurations.connection;

            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            String query = "INSERT INTO user (`login`,`isAdmin`) VALUES ( @login, 0);SELECT LAST_INSERT_ID();";
            MySqlCommand sqlCmd = new MySqlCommand(query, sqlCon);

            sqlCmd.Parameters.Add(new MySqlParameter("@login", username));

            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.ExecuteScalar();
            sqlCon.Close();
            return (int)sqlCmd.LastInsertedId;
        }


        public List<User> GetAllUsers() { 
        MySqlConnection sqlCon = Configurations.connection;

            List<User> result = new List<User>();

            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            String query = "SELECT * FROM user ;";
            MySqlCommand sqlCmd = new MySqlCommand(query, sqlCon);

            sqlCmd.Parameters.Add(new MySqlParameter("@idFormulary", id));

            sqlCmd.CommandType = CommandType.Text;

            MySqlDataReader reader = sqlCmd.ExecuteReader();
            while (reader.Read())
            {
                User user = new User();

                {
                    user.Id = reader.GetInt32(0);
                    user.Login = reader.GetString(1);
                    try{
                        user.Score = reader.GetInt32(4);
                    }
                    catch
                    {
                        user.Score = 0;
                    }
                    
                };
                result.Add(user);
            }
            reader.Close();
            sqlCon.Close();
            return result;        
        }


        public static User getUserById(int id)
        {

            User result = new User();
            MySqlConnection sqlCon = Configurations.connection;

            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            String query = "SELECT * FROM user where idUser = @id ;";
            MySqlCommand sqlCmd = new MySqlCommand(query, sqlCon);
            sqlCmd.Parameters.Add(new MySqlParameter("@id", id));

            sqlCmd.CommandType = CommandType.Text;

            int count = Convert.ToInt32(sqlCmd.ExecuteScalar());
            MySqlDataReader reader = sqlCmd.ExecuteReader();
            while (reader.Read())
            {
                User user = new User();

                {
                    user.Id = reader.GetInt32(0);
                    user.Login = reader.GetString(1);
                    user.isAdmin = reader.GetInt32(4);
                    try{
                        user.Score = reader.GetInt32(4);
                    }
                    catch
                    {
                        user.Score = 0;
                    }
                    
                };

                result = user;
            }
            reader.Close();
            sqlCon.Close();

            return result;
        }
    }

}
