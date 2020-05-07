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
    /// Logique d'interaction pour UserOrientationPage.xaml
    /// </summary>
    public partial class UserOrientationPage : Page
    {
        int playerScore; 
        public UserOrientationPage(int score)
        {
            playerScore = score;
            InitializeComponent();
            if(score < 2)
            {
                OrientationLabel.Content = "Dev";
            }else if (score > -2)
            {
                OrientationLabel.Content = "Réseau";
            }
            else
            {
                OrientationLabel.Content = "Mixte";
            }
        }

        private void mailMe(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new UserMailPage(playerScore));
        }

        private void StartGame(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new QuizzPage(2));
        }
    }
}
