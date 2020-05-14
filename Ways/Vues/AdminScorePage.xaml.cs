


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
    /// Logique d'interaction pour AdminScorePage.xaml
    /// </summary>
    public partial class AdminScorePage : Page
    {
        User user;
        public AdminScorePage()
        {
            InitializeComponent();
             user = new User();
            listUsers.ItemsSource = user.GetAllUsers();
        }



        private void DeleteUserEntry(object sender, RoutedEventArgs e)
        {

            string userID = ((Button)sender).Tag.ToString();
            int id = Int32.Parse(userID);
            bool success = user.deleteUserById(id);
            if(success)
            {
                alertPanel.Background = new SolidColorBrush(Colors.Green);
                resultBox.Text = "La suppression a bien été prise en compte";
                alertPanel.Visibility = Visibility.Visible;
                this.NavigationService.Navigate(new AdminScorePage());

            }
            else
            {
                alertPanel.Background = new SolidColorBrush(Colors.Red);
                resultBox.Text = "Une erreur est survenue veuillez contacter le service de maintenance";

                alertPanel.Visibility = Visibility.Visible;
                this.NavigationService.Navigate(new AdminScorePage());


            }

        }
    }
}


