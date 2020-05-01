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
        private bool isAdmin;
        private int score;

        public bool IsAdmin { get => isAdmin; set => isAdmin = value; }
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
        public bool CreateUser(string login)
        {

            MySqlConnection sqlCon = Configurations.connection;

            try
            {
                if (sqlCon.State == ConnectionState.Closed)
                    sqlCon.Open();
                String query = "INSERT INTO user (login, isAdmin) VALUES (login=@Username, isAdmin=@isAdmin) ";
                    
                    
                MySqlCommand sqlCmd = new MySqlCommand(query, sqlCon);
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.Parameters.AddWithValue("@Username", login);
                sqlCmd.Parameters.AddWithValue("@isAdmin", 0);

                int count = Convert.ToInt32(sqlCmd.ExecuteScalar());
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("LOUPé");
                return false;
            }




        }


    }

}
