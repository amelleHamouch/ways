
using System.Windows;

using Ways.Vues;

namespace Ways
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
         
        }

        private void Button_UserAccess(object sender, RoutedEventArgs e)
        {
            Main.Content = new UserLoginPage();
            AccessUserBtn.Visibility = Visibility.Collapsed;
            AccessAdminBtn.Visibility = Visibility.Collapsed;

        }

        private void Button_AdminAccess(object sender, RoutedEventArgs e)
        {
            Main.Content = new AdminLoginPage();
            AccessUserBtn.Visibility = Visibility.Collapsed;
            AccessAdminBtn.Visibility = Visibility.Collapsed;
        }
    }
}
