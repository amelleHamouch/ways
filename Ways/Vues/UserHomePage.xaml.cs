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
    /// Logique d'interaction pour UserHomePage.xaml
    /// </summary>
    public partial class UserHomePage : Page
    {
        User user = new User();

        public UserHomePage(int userId)
        {
            InitializeComponent();
            user = user.getUserById(userId);
            userNameWelcome.Content = "Bonjour" + user.Login;

        }
        public UserHomePage()
        {
            
            InitializeComponent();
            

        }

        private void StartGame(object sender, RoutedEventArgs e)
        {

        }
    }
}
