using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Ways.Classes;

namespace Ways.Vues
{
    /// <summary>
    /// Logique d'interaction pour AdminLoginPage.xaml
    /// </summary>
    public partial class AdminLoginPage : Page
    {
        public AdminLoginPage()
        {
            InitializeComponent();
        }

        private void SubmitAdmin(object sender, RoutedEventArgs e)
        {
            MySqlConnection sqlCon = Configurations.connection;

            try
            {
                if (sqlCon.State == ConnectionState.Closed)
                    sqlCon.Open();
                String query = "SELECT COUNT(1) FROM user WHERE login=@Username AND password=@Password";
                MySqlCommand sqlCmd = new MySqlCommand (query, sqlCon);
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.Parameters.AddWithValue("@Username", adminLogin.Text);
                sqlCmd.Parameters.AddWithValue("@Password", adminPassBox.Password);
                int count = Convert.ToInt32(sqlCmd.ExecuteScalar());
                if (count == 1)
                {
                    Console.WriteLine("Réussi");
                    this.NavigationService.Navigate(new HomeAdminPage()) ;
                }
                else
                {
                    MessageBox.Show("Identifiant ou mot de passe incorrect.");
                    Console.WriteLine("LOUPé");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("LOUPé");
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sqlCon.Close();
            }
        }
    }
}
    
