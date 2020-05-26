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
    /// Logique d'interaction pour UserScorePage.xaml
    /// </summary>
    public partial class UserScorePage : Page
    {
         User user;
        int scoreUser;
        string userOrientation;
        public UserScorePage(string orientation, int score ,int id)
        {
            InitializeComponent();
            user = new User();
            user = User.getUserById(id);
            scoreUser = score;
            user.updateUserScore(scoreUser, user.Id);
            userOrientation = orientation; listUsers.ItemsSource = user.GetAllUsers();
            ScoreLabel.Content = "Total :" + score.ToString();
            

        }

        private void ClickNext(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new UserMailPage(userOrientation.ToString(), scoreUser, user.Id));

        }
    }
}
