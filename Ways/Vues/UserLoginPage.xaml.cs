using System;
using System.Collections.Generic;
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
    /// Logique d'interaction pour UserLoginPage.xaml
    /// </summary>
    public partial class UserLoginPage : Page
    {
        public UserLoginPage()
        {
            InitializeComponent();
        }

        private void SubmitUser(object sender, RoutedEventArgs e)
        {
            {
                

                User user = new User();
                String login = userLogintxt.Text;
                bool result =user.CreateUser(login);

                if (result == true)
                {
                    Console.WriteLine("Réussi");
                    this.NavigationService.Navigate(new UserHomePage());
                }
                else
                {
                    MessageBox.Show("Une erreur a eu lieu ");
                    Console.WriteLine("LOUPé");
                }


            }
        }
      
    }

}
