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
    /// Logique d'interaction pour HomeAdminPage.xaml
    /// </summary>
    public partial class HomeAdminPage : Page
    {
        public HomeAdminPage()
        {
           
            InitializeComponent();

            quizzView.Content = new FormularyListPage();
            emailingView.Content = new AdminEmailSettingsPage();
            score.Content = new AdminScorePage();
            //Id du formulaire de départ et Id Admin
            Test.Content = new QuizzPage(1,2);

        }


    }
}
