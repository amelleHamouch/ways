using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
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
    /// Logique d'interaction pour UserMailPage.xaml
    /// </summary>
    public partial class UserMailPage : Page
    {
        public UserMailPage(int orientation)
        {
            InitializeComponent();
        }

        public UserMailPage(int orientation, int score)
        {
            InitializeComponent();
        }

        private void sendAllEmails(object sender, RoutedEventArgs e)
        {
            Mail.sendMainMail("nicolas.pinhal@viacesi.fr");
            //this.NavigationService.Navigate(new UserEndPage());

        }

        
    }
}
