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

namespace Ways.Vues
{
    /// <summary>
    /// Logique d'interaction pour WaysHomePage.xaml
    /// </summary>
    public partial class WaysHomePage : Page
    {
        public WaysHomePage()
        {
            InitializeComponent();
        }
        private void Button_UserAccess(object sender, RoutedEventArgs e)
        {

            this.NavigationService.Navigate(new UserLoginPage());

        }

        private void Button_AdminAccess(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new AdminLoginPage());

        }
    }
}
