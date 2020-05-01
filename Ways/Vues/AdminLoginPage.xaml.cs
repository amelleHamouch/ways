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

            User admin = new User(adminLogin.Text, adminPassBox.Password);
            Boolean result = admin.AdminConnect(admin);


                if (result == true)
            {
                Console.WriteLine("Réussi");
                this.NavigationService.Navigate(new HomeAdminPage());
            }
            else
            {
                MessageBox.Show("Identifiant ou mot de passe incorrect.");
                Console.WriteLine("LOUPé");
            }

            
        }
    }
}
    
