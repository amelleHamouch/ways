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
    /// Logique d'interaction pour UserEndPage.xaml
    /// </summary>
    public partial class UserEndPage : Page
    {
        int userId;
        public UserEndPage(int userId)
        {
            this.userId = userId;

            InitializeComponent();
        }

        private void startBonusQuizz(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new QuizzPage(3, userId));
        }
    }
}
